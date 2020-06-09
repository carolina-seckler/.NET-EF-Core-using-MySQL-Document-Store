using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.NUnitTest.Repository
{
    class PublisherRepositoryTests
    {
        [TestFixture]
        public class PublisherRepository_AddBook
        {
            private Mock<IPublisherRepository> _publisherRepository;

            [SetUp]
            public void SetUp()
            {
                _publisherRepository = new Mock<IPublisherRepository>();

            }

            [Test]
            public void AddPublisher_InputIsValidPublisher()
            {
                //Arrange


                //Act
                _publisherRepository.Object.Create(GetPublisher().Object);

                //Assert
                _publisherRepository.Verify();
            }

            [Test]
            public void RemovePublisher_RemoveIsValid()
            {
                //Arrange


                //Act
                _publisherRepository.Object.Delete(GetPublisher().Object.Id);

                //Assert
                _publisherRepository.Verify();
            }
        }

        public static Mock<Publisher> GetPublisher()
        {
            Mock<Publisher> publisher = new Mock<Publisher>();
            publisher.Object.Id = 1;
            publisher.Object.Name = "test";
            publisher.Object.Address = "{\"city\" : \"test\"}";
            return publisher;
        }
    }
}
