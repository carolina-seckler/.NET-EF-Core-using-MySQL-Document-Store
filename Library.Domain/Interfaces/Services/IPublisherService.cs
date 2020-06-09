using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Interfaces.Services
{
    public interface IPublisherService
    {
        void AddPublisher(Publisher publisher);
        void RemovePublisherById(int id);
        IEnumerable<Publisher> GetAllPublishers();
        Publisher GetPublisherById(int id);
        void UpdatePublisher(Publisher publisher);
        IEnumerable<Publisher> GetPublishersByCity(string city);
    }
}
