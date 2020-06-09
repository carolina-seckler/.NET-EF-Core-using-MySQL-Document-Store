using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Interfaces.Repositories
{
    public interface IPublisherRepository : IRepository<int, Publisher>
    {
        IEnumerable<Publisher> ReadByCity(string city);
    }
}
