using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Infra.DataAccess.Repositories
{
    public class PublisherMySQLRepository : RepositoryBase<int, Publisher>, IPublisherRepository
    {
        private DbContext _context;

        public PublisherMySQLRepository(DbContext context)
           : base(context)
        {
            _context = context;
        }

        public IEnumerable<Publisher> ReadByCity(string city)
        {
            var query = _context.Set<Publisher>().Where(p => p.Address != null);
            List<Publisher> result = new List<Publisher>();
            foreach (var item in query)
            {
                JObject rss = JObject.Parse(item.Address);
                var rssCity = rss["city"];
                if (rssCity != null) 
                {
                    if (city.ToLower().Equals(rssCity.ToString().ToLower()))
                        result.Add(item);
                }
            }
            return result;
        }
    }
}
