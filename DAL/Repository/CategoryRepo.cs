using ADOToolbox;
using DAL.Interface;
using DAL.Models;
using DAL.Tools;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repository
{
    class CategoryRepo : BaseRepository, ICategoryRepo<Category>
    {
        public CategoryRepo(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [Category] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Category> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [Category]");
            return _connection.ExecuteReader<Category>(cmd, Converters.CategoryConvert);
        }

        public Category GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Category] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.CategoryConvert).FirstOrDefault();
        }

        public void Insert(Category c)
        {
            string query = "INSERT INTO [Category] (Name, Sidebar) VALUES (@name, @sidebar)";
            Command cmd = new Command(query);
            cmd.AddParameter("name", c.Name);
            cmd.AddParameter("sidebar", c.Sidebar);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Category c)
        {
            string query = "UPDATE [Category] SET Name = @name, Sidebar = @sidebar" +
                "WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("name", c.Name);
            cmd.AddParameter("sidebar", c.Sidebar);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
