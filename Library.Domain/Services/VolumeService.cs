using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Library.Domain.Interfaces.Services;
using Library.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Domain.Services
{
    public class VolumeService : IVolumeService
    {
        private IUnitOfWork _uow;
        private IVolumeRepository _volumeRepository;

        public VolumeService(IUnitOfWork uow, IVolumeRepository volumeRepository)
        {
            _uow = uow;
            _volumeRepository = volumeRepository;
        }

        public void AddVolume(Volume volume)
        {
            _uow.BeginTransaction();
            _volumeRepository.Create(volume);
            _uow.Commit();
        }

        public void RemoveVolumeById(int id)
        {
            _uow.BeginTransaction();
            _volumeRepository.Delete(id);
            _uow.Commit();
        }

        public IEnumerable<Volume> GetAllVolumes()
        {
            return _volumeRepository.ReadAll().ToList();
        }

        public Volume GetVolumeById(int id)
        {
            return _volumeRepository.ReadById(id);
        }


        public void UpdateVolume(Volume volume)
        {
            _uow.BeginTransaction();
            _volumeRepository.Update(volume);
            _uow.Commit();
        }
    }
}
