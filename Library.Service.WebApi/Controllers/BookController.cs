using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Application.Commands.Model;
using Library.Application.Interfaces.ApiApp;
using Library.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookApiApp _bookApiApp;

        public BookController(IBookApiApp bookApiApp)
        {
            _bookApiApp = bookApiApp;
        }

        // POST: api/Book
        [HttpPost]
        public void Post(BookCommandModel model)
        {
            _bookApiApp.AddBook(model);
        }

        // DELETE: api/Book/1
        [HttpDelete("{id}")]
        public void Delete(int id) 
        {
            _bookApiApp.RemoveBookById(id);
        }

        // GET: api/Book
        [HttpGet]
        public IEnumerable<BookCommandModel> Get()
        {
            return _bookApiApp.GetAllBooks();
        }

        // GET: api/Book/1
        [HttpGet("{id}")]
        public BookCommandModel GetById(int id)
        {
            return _bookApiApp.GetBookById(id);
        }

        // PUT: api/Book/1
        [HttpPut("{id}")]
        public void Put(int id, BookCommandModel model)
        {
            model.Id = id;
            _bookApiApp.UpdateBook(model);
        }
    }
}
