using Library.Application.Commands.Model;
using Library.Application.Interfaces.ApiApp;
using Library.Application.Interfaces.Command;
using Library.Domain.Entities;
using Library.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application
{
    public class VolumeApiApp : IVolumeApiApp
    {
        private readonly IVolumeService _volumeService;
        private readonly IVolumeCommandMapper _volumeCommandMapper;

        public VolumeApiApp(IVolumeService volumeService, IVolumeCommandMapper volumeCommandMapper)
        {
            _volumeCommandMapper = volumeCommandMapper;
            _volumeService = volumeService;
        }

        public void AddVolume(VolumeCommandModel model)
        {
            var volume = _volumeCommandMapper.AddVolumeMapper(model);
            _volumeService.AddVolume(volume);
        }

        public void RemoveVolumeById(int id)
        {
            _volumeService.RemoveVolumeById(id);
        }

        public IEnumerable<VolumeCommandModel> GetAllVolumes()
        {
            var volumes = _volumeService.GetAllVolumes();
            IEnumerable<VolumeCommandModel> model = null;
            if (volumes != null)
                model = _volumeCommandMapper.GetAllVolumesMapper(volumes);
            return model;
        }

        public VolumeCommandModel GetVolumeById(int id)
        {
            var volume = _volumeService.GetVolumeById(id);
            VolumeCommandModel model = null;
            if (volume != null)
                model = _volumeCommandMapper.GetVolumeByIdMapper(volume);
            return model;
        }

        public void UpdateVolume(VolumeCommandModel model)
        {
            var volume = _volumeCommandMapper.UpdateVolumeMapper(model);
            if (volume != null)
                _volumeService.UpdateVolume(volume);
        }
    }
}
