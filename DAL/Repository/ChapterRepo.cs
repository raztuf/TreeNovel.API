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
    public class ChapterRepo : BaseRepository, IChapterRepo<Chapter>
    {
        public ChapterRepo(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE * FROM [Chapter] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Chapter> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [Chapter]");
            return _connection.ExecuteReader<Chapter>(cmd, Converters.ChapterConvert);
        }

        public IEnumerable<Chapter> GetByUserId(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Chapter] WHERE UserId = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader<Chapter>(cmd, Converters.ChapterConvert);
        }

        public Chapter GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Chapter] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.ChapterConvert).FirstOrDefault();
        }

        public void Insert(Chapter c)
        {
            string query = "INSERT INTO [Chapter] (Title, Content, Date, UserId, LastChapterId, Encyclopedia) VALUES (@title, @content, @date, @userId, @lastChapterId, @encyclopedia)";
            Command cmd = new Command(query);
            cmd.AddParameter("title", c.Title);
            cmd.AddParameter("content", c.Content);
            cmd.AddParameter("date", DateTime.Today);
            cmd.AddParameter("userId", c.UserId);
            cmd.AddParameter("lastChapterId", c.LastChapterId);
            cmd.AddParameter("encyclopedia", c.Encyclopedia);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Chapter c)
        {
            string query = "UPDATE [Chapter] SET Title = @title, Content = @content, UserId = @userId, LastChapterId = @lastChapterId, Encyclopedia = @encyclopedia" +
                "WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("title", c.Title);
            cmd.AddParameter("content", c.Content);
            cmd.AddParameter("userId", c.UserId);
            cmd.AddParameter("lastChapterId", c.LastChapterId);
            cmd.AddParameter("encyclopedia", c.Encyclopedia);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
