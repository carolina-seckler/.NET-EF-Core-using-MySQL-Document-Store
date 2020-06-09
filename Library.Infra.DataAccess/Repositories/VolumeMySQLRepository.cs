using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infra.DataAccess.Repositories
{
    public class VolumeMySQLRepository : RepositoryBase<int, Volume>, IVolumeRepository
    {
        public VolumeMySQLRepository(DbContext context)
           : base(context)
        {
        }
    }
}
