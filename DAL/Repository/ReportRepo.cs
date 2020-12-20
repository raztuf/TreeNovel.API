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
    public class ReportRepo : BaseRepository, IReportRepo<Report>
    {
        public ReportRepo(IConfiguration config) : base(config)
        {
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE FROM [Report] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<Report> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [Report]");
            return _connection.ExecuteReader<Report>(cmd, Converters.ReportConvert);
        }

        public Report GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [Report] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.ReportConvert).FirstOrDefault();
        }

        public void Insert(Report r)
        {
            string query = "INSERT INTO [Report] (Title, Content, Date, UserId, Subject) VALUES (@title, @content, @date, @userId, @subject)";
            Command cmd = new Command(query);
            cmd.AddParameter("title", r.Title);
            cmd.AddParameter("content", r.Content);
            cmd.AddParameter("date", DateTime.Today);
            cmd.AddParameter("userId", r.UserId);
            cmd.AddParameter("subject", r.Subject);
            _connection.ExecuteNonQuery(cmd);
        }
    }
}
