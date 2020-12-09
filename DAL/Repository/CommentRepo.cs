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
    public class CommentRepo : BaseRepository, ICommentRepo<Comment>
    {
        public CommentRepo(IConfiguration config) : base(config)
        {

        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE * FROM [Comment] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Comment> GetAll(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Comment] WHERE ChapterId = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader<Comment>(cmd, Converters.CommentConvert);
        }

        public Comment GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Comment] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.CommentConvert).FirstOrDefault();
        }

        public void Insert(Comment c)
        {
            string query = "INSERT INTO [Comment] (Content, Date, UserId, ChapterId) VALUES (@content, @date, @userId, @chapterId)";
            Command cmd = new Command(query);
            cmd.AddParameter("content", c.Content);
            cmd.AddParameter("date", DateTime.Today);
            cmd.AddParameter("userId", c.UserId);
            cmd.AddParameter("ChapterId", c.ChapterId);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Comment c)
        {
            string query = "UPDATE [Chapter] SET Content = @content, UserId = @userId, ChapterId = @chapterId" +
                "WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("content", c.Content);
            cmd.AddParameter("userId", c.UserId);
            cmd.AddParameter("chapterId", c.ChapterId);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
