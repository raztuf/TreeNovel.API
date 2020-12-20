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
    public class DiscussionRepo : BaseRepository, IDiscussionRepo<Discussion>
    {
        public DiscussionRepo(IConfiguration config) : base(config)
        {

        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [Discussion] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Discussion> GetAllMains()
        {
            Command cmd = new Command("SELECT * FROM [Discussion] WHERE ReplyToId = 0 OR ReplyToId IS NULL");
            return _connection.ExecuteReader<Discussion>(cmd, Converters.DiscussionConvert);
        }

        public IEnumerable<Discussion> GetAllReplys(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Discussion] WHERE ReplyToId = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader<Discussion>(cmd, Converters.DiscussionConvert);
        }

        public Discussion GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Discussion] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.DiscussionConvert).FirstOrDefault();
        }

        public void Insert(Discussion c)
        {
            string query = "INSERT INTO [Discussion] (Title, Content, Date, ReplyToId, UserId) VALUES (@title, @content, @date, @replyToId, @userId)";
            Command cmd = new Command(query);
            cmd.AddParameter("title", c.Title);
            cmd.AddParameter("content", c.Content);
            cmd.AddParameter("date", DateTime.Today);
            cmd.AddParameter("replyToId", c.ReplyToId);
            cmd.AddParameter("userId", c.UserId);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Discussion c)
        {
            string query = "UPDATE [Discussion] SET Title = @title, Content = @content, ReplyToId = @replyToId, UserId = @userId" +
                "WHERE Id = @Id";
            Command cmd = new Command(query); 
            cmd.AddParameter("title", c.Title);
            cmd.AddParameter("content", c.Content);
            cmd.AddParameter("replyToId", c.ReplyToId);
            cmd.AddParameter("userId", c.UserId);
            cmd.AddParameter("Id", c.Id);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
