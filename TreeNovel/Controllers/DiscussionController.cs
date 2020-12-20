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
    public class DiscussionController : ControllerBase
    {
        private IDiscussionService _discussionService;
        public DiscussionController(IDiscussionService discussionService)
        {
            _discussionService = discussionService;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllMains()
        {
            try
            {
                return Ok(_discussionService.GetAllMains());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{thread}/{Id}")]
        public IActionResult GetAllReplys(int Id)
        {
            try
            {
                return Ok(_discussionService.GetAllReplys(Id));
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
            return Ok(_discussionService.GetOne(Id));
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody] LocalModel.Models.DiscussionToDal d)
        {
            try
            {
                _discussionService.Insert(d);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [AllowAnonymous]
        [HttpPut]
        public IActionResult Put([FromBody] LocalModel.Models.DiscussionToDal d)
        {
            try
            {
                _discussionService.Update(d);
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
                _discussionService.Delete(Id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
