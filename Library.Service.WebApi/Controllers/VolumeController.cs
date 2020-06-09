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
    public class VolumeController : ControllerBase
    {
        private readonly IVolumeApiApp _volumeApiApp;

        public VolumeController(IVolumeApiApp volumeApiApp)
        {
            _volumeApiApp = volumeApiApp;
        }

        // POST: api/Book
        [HttpPost]
        public void Post(VolumeCommandModel model)
        {
            _volumeApiApp.AddVolume(model);
        }

        // DELETE: api/Book/1
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _volumeApiApp.RemoveVolumeById(id);
        }

        // GET: api/Book
        [HttpGet]
        public IEnumerable<VolumeCommandModel> Get()
        {
            return _volumeApiApp.GetAllVolumes();
        }

        // GET: api/Book/1
        [HttpGet("{id}")]
        public VolumeCommandModel GetById(int id)
        {
            return _volumeApiApp.GetVolumeById(id);
        }

        // PUT: api/Book/1
        [HttpPut("{id}")]
        public void Put(int id, VolumeCommandModel model)
        {
            model.Id = id;
            _volumeApiApp.UpdateVolume(model);
        }
    }
}
