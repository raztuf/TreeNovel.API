using dal = DAL.Models;
using local = LocalModel.Models;

namespace LocalModel.Tools
{
    public static class Mappers
    {
        public static local.User toLocal(this dal.User u)
        {
            return new local.User
            {
                Id = u.Id,
                Username = u.Username,
                Mail = u.Mail,
                Password = u.Password,
                IsActive = u.IsActive,
                IsAdmin = u.IsAdmin
            };
        }

        public static dal.User toDal(this local.User u)
        {
            return new dal.User
            {
                Id = u.Id,
                Username = u.Username,
                Mail = u.Mail,
                Password = u.Password,
                IsActive = u.IsActive,
                IsAdmin = u.IsAdmin
            };
        }

        public static local.Chapter toLocal(this dal.Chapter c)
        {
            return new local.Chapter
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                Date = c.Date,
                UserId = c.UserId,
                LastChapterId = c.LastChapterId,
                Encyclopedia = c.Encyclopedia
            };
        }

        public static dal.Chapter toDal(this local.Chapter c)
        {
            return new dal.Chapter
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                Date = c.Date,
                UserId = c.UserId,
                LastChapterId = c.LastChapterId,
                Encyclopedia = c.Encyclopedia
            };
        }

        public static local.Comment toLocal(this dal.Comment c)
        {
            return new local.Comment
            {
                Id = c.Id,
                Content = c.Content,
                Date = c.Date,
                UserId = c.UserId,
                ChapterId = c.ChapterId
            };
        }

        public static dal.Comment toDal(this local.Comment c)
        {
            return new dal.Comment
            {
                Id = c.Id,
                Content = c.Content,
                Date = c.Date,
                UserId = c.UserId,
                ChapterId = c.ChapterId
            };
        }

        public static local.Discussion toLocal(this dal.Discussion d)
        {
            return new local.Discussion
            {
                Id = d.Id,
                Title = d.Title,
                Content = d.Content,
                Date = d.Date,
                ReplyToId = d.ReplyToId,
                UserId = d.UserId
            };
        }

        public static dal.Discussion toDal(this local.Discussion d)
        {
            return new dal.Discussion
            {
                Id = d.Id,
                Title = d.Title,
                Content = d.Content,
                Date = d.Date,
                ReplyToId = d.ReplyToId,
                UserId = d.UserId
            };
        }
    }
}
