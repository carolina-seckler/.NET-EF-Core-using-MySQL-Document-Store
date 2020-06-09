using Library.Application.Commands.Model;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces.Command
{
    public interface IBookCommandMapper
    {
        Book AddBookMapper(BookCommandModel model);
        Book UpdateBookMapper(BookCommandModel model);
        IEnumerable<BookCommandModel> GetAllBooksMapper(IEnumerable<Book> books);
        BookCommandModel GetBookByIdMapper(Book book);
    }
}
