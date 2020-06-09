using Library.Application.Interfaces.ApiApp;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application
{
    public class PublisherApiApp : IPublisherApiApp
    {
        private readonly IPublisherService _publisherService;

        public PublisherApiApp(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        public void AddPublisher(Publisher publisher)
        {
            _publisherService.AddPublisher(publisher);
        }

        public void RemovePublisherById(int id)
        {
            _publisherService.RemovePublisherById(id);
        }

        public IEnumerable<Publisher> GetAllPublishers()
        {
            return _publisherService.GetAllPublishers();
        }

        public Publisher GetPublisherById(int id)
        {
            return _publisherService.GetPublisherById(id);
        }

        public void UpdatePublisher(Publisher publisher)
        {
            _publisherService.UpdatePublisher(publisher);
        }

        public IEnumerable<Publisher> GetPublishersByCity(string city)
        {
            return _publisherService.GetPublishersByCity(city);
        }
    }
}
