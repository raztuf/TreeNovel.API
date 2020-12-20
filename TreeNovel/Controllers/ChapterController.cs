using LocalModel.Models;
using LocalModel.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeNovel.Models;
using TreeNovel.Tools;
using LocalModel.Services;

namespace TreeNovel.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class ChapterController : ControllerBase
    {
        private IChapterService _chapterService;
        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_chapterService.GetAll());
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("reply/{Id}")]
        public IActionResult GetReplies(int Id)
        {
            try
            {
                return Ok(_chapterService.GetReplies(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_chapterService.GetOne(Id));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] LocalModel.Models.ChapterToDal c)
        {
            _chapterService.Insert(c);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put([FromBody] LocalModel.Models.ChapterToDal c)
        {
            try
            {
                _chapterService.Update(c);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _chapterService.Delete(Id);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("genre/{Name}")]
        public IActionResult GetByCategory (string Name)
        {
            try
            {
                return Ok(_chapterService.GetByCategory(Name));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
