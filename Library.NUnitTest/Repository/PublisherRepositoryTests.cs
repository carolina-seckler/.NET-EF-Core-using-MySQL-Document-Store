using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.NUnitTest.Repository
{
    class PublisherRepositoryTests
    {
        [TestFixture]
        public class PublisherRepository
        {
            private Mock<IPublisherRepository> _publisherRepository = new Mock<IPublisherRepository>();
            public readonly IPublisherRepository MockPublisherRepository;

            public PublisherRepository() 
            {
                MockPublisherRepository = _publisherRepository.Object;
            }

            [SetUp]
            public void SetUp()
            {
                _publisherRepository.Setup(mr => mr.ReadAll()).Returns(GetPublishers());

                _publisherRepository.Setup(mr => mr.ReadById(
                    It.IsAny<int>())).Returns((int i) => GetPublishers().Where(
                    x => x.Id == i).Single());

                _publisherRepository.Setup(mr => mr.ReadByCityDapper(
                    It.IsAny<string>())).Returns((string s) => GetPublishers().Where(
                    x => x.Address.Contains(s)));

                _publisherRepository.Setup(mr => mr.Create(It.IsAny<Publisher>()));

                _publisherRepository.Setup(mr => mr.Delete(It.IsAny<int>()));
            }

            [Test]
            public void AddPublisher_InputIsValidPublisher()
            {
                //Arrange


                //Act
                MockPublisherRepository.Create(GetPublisher().Object);

                //Assert
                Assert.AreEqual(2, _publisherRepository.Object.ReadAll().Count());
            }

            [Test]
            public void RemovePublisher_RemoveIsValid()
            {
                //Arrange


                //Act
                MockPublisherRepository.Delete(GetPublishers().First().Id);

                //Assert
                Assert.AreEqual(2, _publisherRepository.Object.ReadAll().Count());
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

        public static IEnumerable<Publisher> GetPublishers()
        {
            List<Publisher> listPublishers = new List<Publisher>();
            Mock <Publisher> publisher1 = new Mock<Publisher>();
            publisher1.Object.Id = 2;
            publisher1.Object.Name = "test2";
            publisher1.Object.Address = "{\"city\" : \"test2\"}";
            listPublishers.Add(publisher1.Object);
            Mock<Publisher> publisher2 = new Mock<Publisher>();
            publisher2.Object.Id = 3;
            publisher2.Object.Name = "test3";
            publisher2.Object.Address = null;
            listPublishers.Add(publisher1.Object);
            return listPublishers;
        }
    }
}
