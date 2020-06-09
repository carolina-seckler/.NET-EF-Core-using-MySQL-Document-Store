using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Domain.Interfaces.Repositories;

namespace Library.Infra.DataAccess.Repositories
{
    public class BookMySQLRepository : RepositoryBase<int, Book>, IBookRepository
    {
        public BookMySQLRepository(DbContext context)
           : base(context)
        {
        }
    }
}
