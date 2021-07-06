using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RocketApi.Contracts;
using RocketApi.Web.Models.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace RocketApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public OwnerController(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var items = _repoWrapper.Owner.FindAll();

            var dtos = _mapper.Map<IEnumerable<OwnerDto>>(items);

            return Ok(dtos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var owner = _repoWrapper.Owner.FindById(id);

            if (owner == null) return NotFound();

            var dto = _mapper.Map<OwnerDto>(owner);

            return Ok(dto);
        }
    }
}
