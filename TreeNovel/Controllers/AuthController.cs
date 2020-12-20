using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeNovel.Models;
using TreeNovel.Services;

namespace TreeNovel.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult Auth([FromBody]LoginInfo model)
        {
            UserToken user = _tokenService.Authenticate(model.Mail, model.Password);
            if(user == null)
            {
                return BadRequest(new { message = "User doesn't exist." });
            }
            return Ok(user);
        }
    }
}
