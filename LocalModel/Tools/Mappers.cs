using DAL.Interface;
using DAL.Models;
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

        public static local.Chapter toLocal(this dal.Chapter c, IUserRepo<dal.User> _userService)
        {
            return new local.Chapter
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                Date = c.Date,
                Writer = _userService.GetOne(c.UserId).toLocal(),
                LastChapterId = c.LastChapterId,
                Encyclopedia = c.Encyclopedia,
                CategoryName = c.CategoryName
            };
        }

        public static dal.Chapter toDal(this local.ChapterToDal c)
        {
            return new dal.Chapter
            {
                Id = c.Id,
                Title = c.Title,
                Content = c.Content,
                Date = c.Date,
                UserId = c.UserId,
                LastChapterId = c.LastChapterId,
                Encyclopedia = c.Encyclopedia,
                CategoryName = c.CategoryName
            };
        }

        public static local.Comment toLocal(this dal.Comment c, IUserRepo<dal.User> _userService)
        {
            return new local.Comment
            {
                Id = c.Id,
                Content = c.Content,
                Date = c.Date,
                Writer = _userService.GetOne(c.UserId).toLocal(),
                ChapterId = c.ChapterId
            };
        }

        public static dal.Comment toDal(this local.CommentToDal c)
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

        public static local.Discussion toLocal(this dal.Discussion d, IUserRepo<dal.User> _userService)
        {
            return new local.Discussion
            {
                Id = d.Id,
                Title = d.Title,
                Content = d.Content,
                Date = d.Date,
                ReplyToId = d.ReplyToId,
                Writer = _userService.GetOne(d.UserId).toLocal()
            };
        }

        public static dal.Discussion toDal(this local.DiscussionToDal d)
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

        public static local.Article toLocal(this dal.Article a)
        {
            return new local.Article
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                Date = a.Date
            };
        }

        public static dal.Article toDal(this local.Article a)
        {
            return new dal.Article
            {
                Id = a.Id,
                Title = a.Title,
                Content = a.Content,
                Date = a.Date
            };
        }

        public static local.Report toLocal(this dal.Report r)
        {
            return new local.Report
            {
                Id = r.Id,
                Title = r.Title,
                Content = r.Content,
                Date = r.Date,
                Subject = r.Subject,
                UserId = r.UserId
            };
        }

        public static dal.Report toDal(this local.Report r)
        {
            return new dal.Report
            {
                Id = r.Id,
                Title = r.Title,
                Content = r.Content,
                Date = r.Date,
                Subject = r.Subject,
                UserId = r.UserId
            };
        }
        public static local.Category toLocal(this dal.Category c)
        {
            return new local.Category
            {
                Id = c.Id,
                Name = c.Name,
                Sidebar = c.Sidebar
            };
        }

        public static dal.Category toDal(this local.Category c)
        {
            return new dal.Category
            {
                Id = c.Id,
                Name = c.Name,
                Sidebar = c.Sidebar
            };
        }

    }
}
