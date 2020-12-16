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
