using Library.Application.Commands.Model;
using Library.Application.Interfaces.Command;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using Library.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Application.Commands.Mapper
{
    public class BookCommandMapper : IBookCommandMapper
    {
        private readonly IBookService _bookService;
        private readonly IPublisherService _publisherService;
        private readonly IPublisherCommandMapper _publisherCommandMapper;

        public BookCommandMapper(IBookService bookService, IPublisherService publisherService, IPublisherCommandMapper publisherCommandMapper)
        {
            _bookService = bookService;
            _publisherService = publisherService;
            _publisherCommandMapper = publisherCommandMapper;
        }

        public Book AddBookMapper(BookCommandModel model)
        {
            var book = new Book();
            book.ISBN = model.ISBN;
            book.Author = model.Author;
            book.Language = (Language)model.Language;
            book.IdPublisher = model.IdPublisher;
            book.IdPublisherNavigation = _publisherService.GetPublisherById(model.IdPublisher);
            return book;
        }

        public Book UpdateBookMapper(BookCommandModel model)
        {
            var book = _bookService.GetBookById(model.Id);
            if (book != null) 
            {
                book.ISBN = model.ISBN;
                book.Author = model.Author;
                book.Language = (Language)model.Language;
                book.IdPublisher = model.IdPublisher;
                book.IdPublisherNavigation = _publisherService.GetPublisherById(model.IdPublisher);
            }
            return book;
        }

        public IEnumerable<BookCommandModel> GetAllBooksMapper(IEnumerable<Book> books)
        {
            List<BookCommandModel> models = new List<BookCommandModel>();
            foreach (var book in books)
            {
                BookCommandModel model = GetBookByIdMapper(book);
                models.Add(model);
            }
            return models;
        }

        public BookCommandModel GetBookByIdMapper(Book book) 
        {
            BookCommandModel model = new BookCommandModel();
            model.Id = book.Id;
            model.ISBN = book.ISBN;
            model.Author = book.Author;
            model.Language = (int)book.Language;
            model.IdPublisher = book.IdPublisher;
            Publisher publisher = _publisherService.GetPublisherById(book.IdPublisher);
            if (publisher != null)
                model.Publisher = _publisherCommandMapper.GetPublisherByIdMapper(publisher);
            return model;
        }
    }
}
