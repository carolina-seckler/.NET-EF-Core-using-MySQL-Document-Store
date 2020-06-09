using Library.Application.Commands.Model;
using Library.Application.Interfaces.ApiApp;
using Library.Application.Interfaces.Command;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application
{
    public class BookApiApp : IBookApiApp
    {
        private readonly IBookService _bookService;
        private readonly IBookCommandMapper _bookCommandMapper;

        public BookApiApp(IBookService bookService, IBookCommandMapper bookCommandMapper)
        {
            _bookService = bookService;
            _bookCommandMapper = bookCommandMapper;
        }

        public void AddBook(BookCommandModel model)
        {
            var book = _bookCommandMapper.AddBookMapper(model);
            _bookService.AddBook(book);
        }

        public void RemoveBookById(int id) 
        {
            _bookService.RemoveBookById(id);
        }

        public IEnumerable<BookCommandModel> GetAllBooks()
        {
            var books = _bookService.GetAllBooks();
            IEnumerable<BookCommandModel> model = null;
            if (books != null)
                model = _bookCommandMapper.GetAllBooksMapper(books);
            return model;
        }

        public BookCommandModel GetBookById(int id) 
        {
            var book = _bookService.GetBookById(id);
            BookCommandModel model = null;
            if (book != null)
                model = _bookCommandMapper.GetBookByIdMapper(book);
            return model;
        }

        public void UpdateBook(BookCommandModel model)
        {
            var book = _bookCommandMapper.UpdateBookMapper(model);
            if (book != null)
                _bookService.UpdateBook(book);
        }
    }
}
