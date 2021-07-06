using Microsoft.AspNetCore.Mvc;
using RocketApi.Contracts;
using RocketApi.Web.Models.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace RocketApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;

        public UserController(IRepositoryWrapper wrapper)
        {
            _repoWrapper = wrapper;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] UserDto dto)
        {
            var item = await _repoWrapper.User
                .FindByCondition(x => x.ScreenName == dto.ScreenName && x.Password == dto.Password);

            var result = item.FirstOrDefault();

            if (result == null) return NotFound();

            return Ok(result.Id);
        }

        [HttpPost]
        [Route("friendship")]
        public async Task<IActionResult> AddFollowee([FromBody] NewFolloweeDto dto)
        {
            var actualUser = await _repoWrapper.User.FindById(1);
            var userToFollow = await _repoWrapper.User.FindUserById(dto.UserId);

            if (userToFollow == null) return BadRequest();

            _repoWrapper.User.AddFollowee(actualUser, userToFollow);

            _repoWrapper.Save();

            return Ok();
        }

        [HttpPost]
        [Route("status")]
        public async Task<IActionResult> CreateStatus([FromBody] StatusDto statusDto)
        {
            var user = await _repoWrapper.User.FindUserById(2);

            _repoWrapper.User.AddStatus(user, statusDto.Content);
            _repoWrapper.Save();

            return Ok();
        }

        [HttpGet]
        [Route("feed")]
        public async Task<IActionResult> GetFolloweesStatuses()
        {
            var statuses = await _repoWrapper.User.GetFolloweesStatuses(2);

            return Ok(statuses);
        }
    }
}
