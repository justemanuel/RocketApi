using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
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
                return StatusCode(500, "Error creating user");
            }
            else
            {
                return BadRequest("Invalid model");
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserRegisterDto dto)
        {

        }
    }
}
