using Library.Domain.Entities;
using Library.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Library.Infra.DataAccess.Repositories
{
    public class PublisherMySQLRepository : RepositoryBase<int, Publisher>, IPublisherRepository
    {
        private DbContext _context;
        private readonly IConfiguration Configuration;

        public PublisherMySQLRepository(DbContext context, IConfiguration configuration)
           : base(context)
        {
            _context = context;
            Configuration = configuration;
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

        public IEnumerable<Publisher> ReadByCityDapper(string city)
        {
            var connection = new MySqlConnection(Configuration.GetConnectionString("InfnetConnection"));
            var result = connection.Query<Publisher>(
                    "SELECT * FROM Library.Publisher " +
                    "WHERE Address->'$.city' = @cityIndicator",
                    new { cityIndicator = city });
            return result;
        }
    }
}
