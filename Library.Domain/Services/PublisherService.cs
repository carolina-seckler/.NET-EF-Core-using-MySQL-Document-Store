using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Library.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Services
{
    public class PublisherService : IPublisherService
    {
        private IUnitOfWork _uow;
        private IPublisherRepository _publisherRepository;

        public PublisherService(IUnitOfWork uow, IPublisherRepository publisherRepository)
        {
            _uow = uow;
            _publisherRepository = publisherRepository;
        }

        public void AddPublisher(Publisher publisher)
        {
            _uow.BeginTransaction();
            _publisherRepository.Create(publisher);
            _uow.Commit();
        }

        public void RemovePublisherById(int id)
        {
            _uow.BeginTransaction();
            _publisherRepository.Delete(id);
            _uow.Commit();
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherRepository.ReadAll();
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherRepository.ReadById(id);
        }


        public void UpdatePublisher(Publisher publisher)
        {
            _uow.BeginTransaction();
            _publisherRepository.Update(publisher);
            _uow.Commit();
        }

        public IEnumerable<Publisher> GetPublishersByCity(string city) 
        {
            return _publisherRepository.ReadByCity(city);
        }
    }
}
