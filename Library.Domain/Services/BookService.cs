using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Library.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Domain.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork _uow;
        private IBookRepository _bookRepository;

        public BookService(IUnitOfWork uow, IBookRepository bookRepository)
        {
            _uow = uow;
            _bookRepository = bookRepository;
        }

        public void AddBook(Book book)
        {
            _uow.BeginTransaction();
            _bookRepository.Create(book);
            _uow.Commit();
        }

        public void RemoveBookById(int id)
        {
            _uow.BeginTransaction();
            _bookRepository.Delete(id);
            _uow.Commit();
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _bookRepository.ReadAll().ToList();
        }

        public Book GetBookById(int id)
        {
            return _bookRepository.ReadById(id);
        }
              

        public void UpdateBook (Book book)
        {
            _uow.BeginTransaction();
            _bookRepository.Update(book);
            _uow.Commit();
        }
    }
}
