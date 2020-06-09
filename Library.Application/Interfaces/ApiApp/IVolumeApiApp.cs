using Library.Application.Commands.Model;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces.ApiApp
{
    public interface IVolumeApiApp
    {
        void AddVolume(VolumeCommandModel volume);
        void RemoveVolumeById(int id);
        IEnumerable<VolumeCommandModel> GetAllVolumes();
        VolumeCommandModel GetVolumeById(int id);
        void UpdateVolume(VolumeCommandModel volume);
    }
}
