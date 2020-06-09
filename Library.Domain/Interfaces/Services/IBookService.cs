using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Interfaces.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        void RemoveBookById(int id);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void UpdateBook(Book book);
    }
}
