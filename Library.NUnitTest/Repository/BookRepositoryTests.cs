using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Model;
using Library.Infra.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.NUnitTest.Repository
{
    class BookRepositoryTests
    {
        [TestFixture]
        public class BookRepository_AddBook
        {
            private Mock<IBookRepository> _bookRepository;

            [SetUp]
            public void SetUp()
            {
                _bookRepository = new Mock<IBookRepository>();
                
            }

            [Test]
            public void AddBook_InputIsValidBook()
            {
                //Arrange
                

                //Act
                _bookRepository.Object.Create(GetBook().Object);

                //Assert
                _bookRepository.Verify();
            }
        }

        public static Mock<Book> GetBook() 
        {
            Mock<Book> book = new Mock<Book>();
            book.Object.Id = 1;
            book.Object.ISBN = "test";
            book.Object.Author = "test";
            book.Object.Language = (Language)0;
            book.Object.IdPublisher = 1;
            book.Object.IdPublisherNavigation = PublisherRepositoryTests.GetPublisher().Object;
            return book;
        }
    }
}
