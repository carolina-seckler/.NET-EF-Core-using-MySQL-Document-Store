using Library.Domain.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Library.Infra.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
        }

        public bool Commit()
        {
            if (_context.SaveChanges() > 0)
                return true;
            return false;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
