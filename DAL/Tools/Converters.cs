using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using System.Data.SqlClient;

namespace DAL.Tools
{
    public class Converters
    {
        public static User Convert(SqlDataReader reader)
        {
            return new User
            {
                Id = (int)reader["Id"],
                Username = reader["Username"].ToString(),
                Mail = reader["Mail"].ToString(),
                Password = reader["Password"].ToString(),
                IsAdmin = reader["IsAdmin"] == DBNull.Value ? false : (bool)reader["IsAdmin"],
                IsActive = reader["IsActive"] == DBNull.Value ? false : (bool)reader["IsActive"],
            };
        }

        public static Chapter ChapterConvert(SqlDataReader reader)
        {
            return new Chapter
            {
                Id = (int)reader["Id"],
                Title = reader["Title"].ToString(),
                Date = (DateTime)reader["Date"],
                Content = reader["Content"].ToString(),
                UserId = (int)reader["UserId"],
                LastChapterId = reader["LastChapterId"] == DBNull.Value ? 0 : (int)reader["LastChapterId"],
                Encyclopedia = reader["Encyclopedia"].ToString()
            };
        }

        public static Comment CommentConvert(SqlDataReader reader)
        {
            return new Comment
            {
                Id = (int)reader["Id"],
                Content = reader["Content"].ToString(),
                Date = (DateTime)reader["Date"],
                UserId = (int)reader["UserId"],
                ChapterId = (int)reader["ChapterId"]
            };
        }

        public static Discussion DiscussionConvert(SqlDataReader reader)
        {
            return new Discussion
            {
                Id = (int)reader["Id"],
                Title = reader["Title"].ToString(),
                Content = reader["Content"].ToString(),
                Date = (DateTime)reader["Date"],
                ReplyToId = reader["ReplyToId"] == DBNull.Value ? 0 : (int)reader["ReplyToId"],
                UserId = (int)reader["UserId"]
            };
        }
    }
}
