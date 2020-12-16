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
    public class StoryRepo : BaseRepository, IStoryRepo<Story>
    {
        public StoryRepo(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [Story] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Story> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [Story]");
            return _connection.ExecuteReader<Story>(cmd, Converters.StoryConvert);
        }

        public IEnumerable<Story> GetByCategory(int Id)
        {
            throw new NotImplementedException();
        }

        public Story GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Story] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.StoryConvert).FirstOrDefault();
        }

        public void Insert(Story s)
        {
            string query = "INSERT INTO [Story] (Title, LastEntry) VALUES (@title, @lastEntry)";
            Command cmd = new Command(query);
            cmd.AddParameter("title", s.Title);
            cmd.AddParameter("lastEntry", s.LastEntry);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Story s)
        {
            string query = "UPDATE [Chapter] SET Title = @title, LastEntry = @lastEntry" +
                "WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("title", s.Title);
            cmd.AddParameter("lastEntry", s.LastEntry);
            _connection.ExecuteNonQuery(cmd);
        }
    }

}
