using LocalModel.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeNovel.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [AllowAnonymous]
        [HttpGet("{chapter}/{Id}")]
        public IActionResult Get(int Id)
        {
            try
            {
                return Ok(_commentService.GetAll(Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{Id}")]
        public IActionResult GetOne(int Id)
        {
            return Ok(_commentService.GetOne(Id));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] LocalModel.Models.CommentToDal c)
        {
            try
            {
                _commentService.Insert(c);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put([FromBody] LocalModel.Models.CommentToDal c)
        {
            try
            {
                _commentService.Update(c);
                return Ok();
            }
            catch (Exception e)
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
                _commentService.Delete(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
