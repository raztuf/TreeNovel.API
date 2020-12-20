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
    public class ArticleRepo: BaseRepository, IArticleRepo<Article>
    {
        public ArticleRepo(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [Article] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Article> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [Article]");
            return _connection.ExecuteReader<Article>(cmd, Converters.ArticleConvert);
        }

        public Article GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Article] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.ArticleConvert).FirstOrDefault();
        }

        public void Insert(Article a)
        {
            string query = "INSERT INTO [Article] (Title, Content, Date) VALUES (@title, @content, @date)";
            Command cmd = new Command(query);
            cmd.AddParameter("title", a.Title);
            cmd.AddParameter("content", a.Content);
            cmd.AddParameter("date", DateTime.Today);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Article a)
        {
            string query = "UPDATE [Article] SET Title = @title, Content = @content WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("title", a.Title);
            cmd.AddParameter("content", a.Content);
            cmd.AddParameter("Id", a.Id);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
