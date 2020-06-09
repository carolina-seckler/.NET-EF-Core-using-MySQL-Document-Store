using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IRepository<int, Book>
    {
    }
}
