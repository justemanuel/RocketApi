using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RocketApi.Services;
using RocketApi.Web.Config;
using RocketApi.Web.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RocketApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenHandlerService _tokenService;

        public AuthController(UserManager<IdentityUser> userManager, ITokenHandlerService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
        {
            if (ModelState.IsValid)
            {
                var userExists = await _userManager.FindByEmailAsync(dto.Email);
                if(userExists != null)
                {
                    return BadRequest("Username already exists");
                }

                var created = await _userManager.CreateAsync(new IdentityUser()
                {
                    UserName = dto.Email,
                    Email = dto.Email
                }, dto.Password);

                if (created.Succeeded) return Ok();
                return BadRequest(created.Errors.Select(x => x.Description));
            }
            else
            {
                return BadRequest("Invalid model");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var validUser = await _userManager.FindByEmailAsync(dto.UserName);
                if (validUser == null)
                {
                    return BadRequest(new UserLoginResponseDto()
                    {
                        Logged = false,
                        Errors = new List<string>()
                        {
                            "Incorrect username"
                        }
                    });
                }

                var isCorrect = await _userManager.CheckPasswordAsync(validUser, dto.Password);

                if (isCorrect)
                {
                    var pars = new TokenParameters()
                    {
                        Id = validUser.Id,
                        PasswordHash = validUser.PasswordHash,
                        UserName = validUser.UserName
                    };

                    var token = _tokenService.GenerateJwtToken(pars);

                    return Ok(new UserLoginResponseDto()
                    {
                        Logged = true,
                        Token = token
                    });
                }

                return BadRequest(new UserLoginResponseDto()
                {
                    Logged = false,
                    Errors = new List<string>()
                    {
                        "Incorret password"
                    }
                });
            }
            else
            {
                return BadRequest(new UserLoginResponseDto()
                {
                    Logged = false,
                    Errors = new List<string>()
                    {
                        "Incorrect username or password"
                    }
                });
            }
        }
    }
}
