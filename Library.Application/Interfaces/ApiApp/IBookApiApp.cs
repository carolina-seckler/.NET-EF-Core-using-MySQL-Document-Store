using Library.Application.Commands.Model;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces.ApiApp
{
    public interface IBookApiApp
    {
        void AddBook(BookCommandModel book);
        void RemoveBookById(int id);
        IEnumerable<BookCommandModel> GetAllBooks();
        BookCommandModel GetBookById(int id);
        void UpdateBook(BookCommandModel book);
    }
}
