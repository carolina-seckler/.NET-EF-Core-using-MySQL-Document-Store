using Library.Application.Commands.Model;
using Library.Application.Interfaces.Command;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Commands.Mapper
{
    public class VolumeCommandMapper : IVolumeCommandMapper
    {
        private readonly IVolumeService _volumeService;
        private readonly IBookService _bookService;
        private readonly IBookCommandMapper _bookCommandMapper;

        public VolumeCommandMapper(IVolumeService volumeService, IBookService bookService, IBookCommandMapper bookCommandMapper)
        {
            _volumeService = volumeService;
            _bookService = bookService;
            _bookCommandMapper = bookCommandMapper;
        }

        public Volume AddVolumeMapper(VolumeCommandModel model)
        {
            var volume = new Volume();
            volume.Title = model.Title;
            volume.Number = model.Number;
            volume.Pages = model.Pages;
            volume.IdBook = model.IdBook;
            volume.IdBookNavigation = _bookService.GetBookById(model.IdBook);
            return volume;
        }

        public Volume UpdateVolumeMapper(VolumeCommandModel model)
        {
            var volume = _volumeService.GetVolumeById(model.Id);
            if (volume != null)
            {
                volume.Title = model.Title;
                volume.Number = model.Number;
                volume.Pages = model.Pages;
                volume.IdBook = model.IdBook;
                volume.IdBookNavigation = _bookService.GetBookById(model.IdBook);
            }
            return volume;
        }

        public IEnumerable<VolumeCommandModel> GetAllVolumesMapper(IEnumerable<Volume> volumes)
        {
            List<VolumeCommandModel> models = new List<VolumeCommandModel>();
            foreach (var volume in volumes)
            {
                VolumeCommandModel model = GetVolumeByIdMapper(volume);
                models.Add(model);
            }
            return models;
        }

        public VolumeCommandModel GetVolumeByIdMapper(Volume volume)
        {
            VolumeCommandModel model = new VolumeCommandModel();
            model.Id = volume.Id;
            model.Title = volume.Title;
            model.Number = volume.Number;
            model.Pages = volume.Pages;
            model.IdBook = volume.IdBook;
            Book book = _bookService.GetBookById(volume.IdBook);
            if (book != null)
                model.Book = _bookCommandMapper.GetBookByIdMapper(book);
            return model;
        }
    }
}
