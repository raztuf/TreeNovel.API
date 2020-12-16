using DAL.Interface;
using LocalModel.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeNovel.Models;

namespace TreeNovel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FStoryController : ControllerBase
    {
        private IFStoryService _fStoryService;
        public FStoryController(IFStoryService fStoryService)
        {
            _fStoryService = fStoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_fStoryService.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int Id)
        {
            return Ok(_fStoryService.GetOne(Id));
        }
    }
}
