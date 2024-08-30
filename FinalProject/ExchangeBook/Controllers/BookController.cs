using AutoMapper;
using ExchangeBook.Data;
using ExchangeBook.DTO.AuthorDTOs;
using ExchangeBook.DTO.BookDTOs;
using ExchangeBook.DTO.PersonDTO;
using ExchangeBook.Services;
using ExchangeBook.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ExchangeBook.Controllers
{
    public class BookController : BaseController
    {
        private readonly IMapper _mapper;

        public BookController(IApplicationService applicationService,
        IMapper mapper) : base(applicationService)
        {
            _mapper = mapper;
        }

        [HttpGet("{title}/books")]
        public async Task<ActionResult<List<BookReadDTOIncludePersons>>> GetBooksByTitle(string? title)
        {
            List<Book>? books = await _applicationService.BookService.GetBooksByTitleAsync(title);
            if (books == null) { throw new BookNotFoundException("Not found Books"); }
            return Ok(_mapper.Map<List<BookReadDTOIncludePersons>>(books));
        }


        [HttpPost("{personId}")]
        public async Task<ActionResult<BookReadOnlyDTO>> AddBookToPerson(int personId, [FromBody] BookInsertDTO bookDto)
        {
            if (!ModelState.IsValid)
            {
                // If the model state is not valid, build a custom response
                var errors = ModelState
                    .Where(e => e.Value!.Errors.Any())
                    .Select(e => new
                    {
                        Field = e.Key,
                        Errors = e.Value!.Errors.Select(error => error.ErrorMessage).ToArray()
                    });

                throw new InvalidRegistrationException("ErrorsInRegistation: " + errors);
            }
            var book = await _applicationService.BookService.CreateBookAsync(bookDto);
            // Add the created book to the person's books (assigning personId and Bookid in Person_Book many-many table
            await _applicationService.PersonService.AddBookToPersonAsync(personId, book.Id);
            //return Ok(_mapper.Map<BookReadOnlyDTO>(book));
            var returnedBookDTO = _mapper.Map<BookReadOnlyDTO>(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, returnedBookDTO);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<BookReadOnlyDTO>> GetBook(int id)
        {
            Book? book = await _applicationService.BookService.GetBookWithAuthorById(id);
            if (book is null)
            {
                throw new BookNotFoundException("Book NotFound");
            }

            BookReadOnlyDTO returnedBook = _mapper.Map<BookReadOnlyDTO>(book);
            //AuthorReadonlyDTO authorReadonly= _mapper.Map<AuthorReadonlyDTO>(book.Author);

            return Ok(returnedBook);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Book>>> GetPersonBooks(int? id)
        {
            List<Book> books = await _applicationService.PersonService.GetPersonBooksAsync(id);
            //List<BookReadOnlyDTO> booksReadOnly;
            if (books is null)
            {
                throw new BookNotFoundException("not found books");
            }
            return Ok(_mapper.Map<List<BookReadOnlyDTO>>(books));
        }
    }

}
