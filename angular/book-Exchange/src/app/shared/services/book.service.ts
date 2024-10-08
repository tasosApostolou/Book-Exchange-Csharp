import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Book, BookWithPersons, BookWithUsers, InsertBook, InsertStoreBook } from '../interfaces/book';
import { environment } from 'src/environments/environment.development';
import { UserService } from './user.service';
const API_URL = `${environment.apiURL}/book`

@Injectable({
  providedIn: 'root'
})
export class BookService {
http:HttpClient = inject(HttpClient)
userService = inject(UserService)
id = this.userService.id
title:string=''
// addBook(book:InsertBook | InsertStoreBook)
addBook(book:InsertBook){
  return this.http.post<{data:JSON}>(`${API_URL}/AddBookToPerson/${this.userService.user().roleEntityId}`,book)
}
addStoreBook(storeBook:InsertStoreBook){
  return this.http.post<{data:JSON}>(`https://localhost:7279/api/Store/AddBookToStore/${this.userService.user().roleEntityId}`,storeBook)
}
getBooksByTitle(title:string){
  this.title=title
  console.log(`title:${this.title}`)
  return this.http.get<BookWithPersons[]>(`https://localhost:7279/api/Book/GetBooksByTitle/${this.title}/books`,{
    headers:{
      Accept:'application/json'
    }
  })
    }
    // https://localhost:7279/api/Book/GetBooksByTitle/{title}/books

  getUserBooks(personId:number){
    return this.http.get <Book[]>(`${API_URL}/person/${personId}`,{
      headers: {
        Accept:'application/json'
      },
    })
  }

  getBookById(bookId:number){
    return this.http.get<Book>(`${API_URL}/${bookId}`,{
      headers: {
        Accept:'application/json'
      },
    })
  }
}
