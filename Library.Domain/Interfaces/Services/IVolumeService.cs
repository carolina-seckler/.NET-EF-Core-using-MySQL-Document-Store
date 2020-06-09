using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Interfaces.Services
{
    public interface IVolumeService
    {
        void AddVolume(Volume volume);
        void RemoveVolumeById(int id);
        IEnumerable<Volume> GetAllVolumes();
        Volume GetVolumeById(int id);
        void UpdateVolume(Volume volume);
    }
}
