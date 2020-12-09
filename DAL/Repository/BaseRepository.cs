using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using ADOToolbox;

namespace DAL.Repository
{
    public class BaseRepository
    {
        internal Connection _connection;

        IConfiguration _config;

        private string _connectionString = @"Data Source=DESKTOP-8JI8Q4K\\FORMATION;Initial Catalog=TreeNovelDb;User ID=sa;Password=baxomYko;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public BaseRepository()
        {
            _connectionString = @"Data Source=DESKTOP-8JI8Q4K\\FORMATION;Initial Catalog=TreeNovelDb;User ID=sa;Password=baxomYko;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public SqlConnection Connection()
        {
            return new SqlConnection(_config.GetConnectionString("default"));
        }

        public BaseRepository(IConfiguration config)
        {
            _config = config;
            _connection = new Connection(config.GetConnectionString("default"));
        }
    }
}
