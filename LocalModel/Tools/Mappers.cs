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
                Encyclopedia = c.Encyclopedia
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
                Encyclopedia = c.Encyclopedia
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

        public static local.Story toLocal(this dal.Story s)
        {
            return new local.Story
            {
                Id = s.Id,
                Title = s.Title,
                LastEntry = s.LastEntry
            };
        }

        public static dal.Story toDal(this local.Story s)
        {
            return new dal.Story
            {
                Id = s.Id,
                Title = s.Title,
                LastEntry = s.LastEntry
            };
        }

        public static local.FStory toLocal(this dal.FStory f)
        {
            return new local.FStory
            {
                Id = f.Id,
                LastId = f.LastId,
                StoryTitle = f.StoryTitle,
                ChapterTitle = f.ChapterTitle,
                ChapterContent = f.ChapterContent,
                ChapterEncyclopedia = f.ChapterEncyclopedia,
                LastChapterId = f.LastChapterId
                
            };
        }
    }
}
