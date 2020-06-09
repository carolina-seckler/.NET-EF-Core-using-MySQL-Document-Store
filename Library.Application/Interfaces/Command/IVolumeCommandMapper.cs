using Library.Application.Commands.Model;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Interfaces.Command
{
    public interface IVolumeCommandMapper
    {
        Volume AddVolumeMapper(VolumeCommandModel model);
        Volume UpdateVolumeMapper(VolumeCommandModel model);
        IEnumerable<VolumeCommandModel> GetAllVolumesMapper(IEnumerable<Volume> volumes);
        VolumeCommandModel GetVolumeByIdMapper(Volume volume);
    }
}
