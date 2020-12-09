using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.Interface;
using Microsoft.Extensions.Configuration;
using DAL.Models;
using ADOToolbox;
using DAL.Tools;

namespace DAL.Repository
{
    public class UserRepo : BaseRepository, IUserRepo<User>
    {
        public UserRepo(IConfiguration config): base(config)
        {

        }

        public bool? CheckUser(User u)
        {
            string Query = "SELECT Id FROM [User] WHERE Mail = @mail AND Password = @password";
            Command cmd = new Command(Query);
            cmd.AddParameter("mail", u.Mail);
            cmd.AddParameter("password", u.Password);

            int Id = (int)_connection.ExecuteScalar(cmd);

            if (Id > 0)
            {
                Command checkActive = new Command("SELECT Id FROM [User] WHERE Id = " + Id + " AND IsActive = 1");
                if ((int)_connection.ExecuteScalar(checkActive) > 0) return true;
                else return false;
            }
            else return null;
        }

        public bool Delete(int Id)
        {
            Command cmd = new Command("DELETE * FROM [User] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteNonQuery(cmd) == 1;
        }

        public IEnumerable<User> GetAll()
        {
            Command cmd = new Command("SELECT * FROM [User]");
            return _connection.ExecuteReader<User>(cmd, Converters.Convert);
        }

        public User GetByMail(string mail)
        {
            Command cmd = new Command("SELECT * FROM [User] WHERE Mail = @mail");
            cmd.AddParameter("mail", mail);
            return _connection.ExecuteReader(cmd, Converters.Convert).FirstOrDefault();
        }

        public User GetOne(int Id)
        {
            Command cmd = new Command("SELECT * FROM [User] WHERE Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.Convert).FirstOrDefault();
        }

        public void Insert(User u)
        {
            string query = "INSERT INTO [User] (Username, Mail, Password) VALUES (@username, @mail, @password)";
            Command cmd = new Command(query);
            cmd.AddParameter("username", u.Username);
            cmd.AddParameter("mail", u.Mail);
            cmd.AddParameter("Password", u.Password);
            _connection.ExecuteNonQuery(cmd);
        }

        public void SetAdmin(int Id)
        {
            string Query = "UPDATE [User] SET IsAdmin = @isAdmin WHERE Id = @id";
            Command cmd = new Command(Query);
            cmd.AddParameter("isAdmin", GetOne(Id).IsAdmin ? 0 : 1);
            cmd.AddParameter("Id", Id);
            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(User u)
        {
            string query = "UPDATE [User] SET Mail = @mail, Password = @password, Username = @username" + 
                "WHERE Id = @Id";
            Command cmd = new Command(query);
            cmd.AddParameter("mail", u.Mail);
            cmd.AddParameter("password", u.Password);
            cmd.AddParameter("userame", u.Username);
            cmd.AddParameter("Id", u.Id);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
