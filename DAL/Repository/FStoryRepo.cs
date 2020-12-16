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
    public class FStoryRepo : BaseRepository, IFStoryRepo<FStory>
    {
        public FStoryRepo(IConfiguration config) : base(config)
        {
        }

        public IEnumerable<FStory> GetAll()
        {
            Command cmd = new Command("SELECT s.Id AS Id, s.LastEntry AS LastId, s.Title AS StoryTitle, ch.Title AS ChapterTitle, ch.Content AS ChapterContent, ch.Encyclopedia AS ChapterEncyclopedia, ch.LastChapterId AS LastChapterId FROM Story s JOIN Chapter ch ON s.LastEntry = ch.Id");
            return _connection.ExecuteReader<FStory>(cmd, Converters.FStoryConvert);
        }

        public FStory GetOne(int Id)
        {
            Command cmd = new Command("SELECT s.Id AS Id, s.LastEntry AS LastId, s.Title AS StoryTitle, ch.Title AS ChapterTitle, ch.Content AS ChapterContent, ch.Encyclopedia AS ChapterEncyclopedia, ch.LastChapterId AS LastChapterId FROM Story s JOIN Chapter ch ON s.LastEntry = ch.Id" +
                "WHERE s.Id = @Id");
            cmd.AddParameter("Id", Id);
            return _connection.ExecuteReader(cmd, Converters.FStoryConvert).FirstOrDefault();
        }
    }
}
