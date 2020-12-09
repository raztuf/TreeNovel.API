﻿using LocalModel.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeNovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscussionController : ControllerBase
    {
        private IDiscussionService _discussionService;
        public DiscussionController(IDiscussionService discussionService)
        {
            _discussionService = discussionService;
        }

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

        [HttpGet("{Id}")]
        public IActionResult GetOne(int Id)
        {
            return Ok(_discussionService.GetOne(Id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] LocalModel.Models.Discussion d)
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

        [HttpPut]
        public IActionResult Put([FromBody] LocalModel.Models.Discussion d)
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