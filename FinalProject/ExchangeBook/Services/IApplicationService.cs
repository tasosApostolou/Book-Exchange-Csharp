﻿using ExchangeBook.Data;

namespace ExchangeBook.Services
{
    public interface IApplicationService
    {
        UserService UserService { get; }
        PersonService PersonService { get; }
        StoreService StoreService { get; }
        BookService BookService { get; }
        StoreBookService StoreBookService { get; }
        NotificationService NotificationService { get; }



    }
}
