using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Application.Interfaces.ApiApp;
using Library.Domain.Entities;
using Library.Service.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherApiApp _publisherApiApp;

        public PublisherController(IPublisherApiApp publisherApiApp)
        {
            _publisherApiApp = publisherApiApp;
        }

        // POST: api/Book
        [HttpPost]
        public void Post(Publisher publisher)
        {
            _publisherApiApp.AddPublisher(publisher);
        }

        // DELETE: api/Book/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _publisherApiApp.RemovePublisherById(id);
        }

        // GET: api/Book
        [HttpGet]
        public IEnumerable<Publisher> Get()
        {
            return _publisherApiApp.GetAllPublishers();
        }

        // GET: api/Book/1
        [HttpGet("{id}")]
        public Publisher GetById(int id)
        {
            return _publisherApiApp.GetPublisherById(id);
        }

        // PUT: api/Book/1
        [HttpPut("{id}")]
        public void Put(int id, Publisher publisher)
        {
            publisher.Id = id;
            _publisherApiApp.UpdatePublisher(publisher);
        }

        // GET: api/Book/city
        [HttpGet("city")]
        public IEnumerable<Publisher> GetByCity(PublisherViewModel model)
        {
            return _publisherApiApp.GetPublishersByCity(model.City);
        }
    }
}
