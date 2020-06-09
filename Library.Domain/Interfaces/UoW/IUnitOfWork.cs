using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Interfaces.UoW
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        bool Commit();
        void Dispose();
    }
}
