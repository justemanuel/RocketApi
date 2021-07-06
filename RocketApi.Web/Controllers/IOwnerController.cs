using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RocketApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RocketApi.Entities.Models;
using RocketApi.Web.Models.DTOs;

namespace RocketApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IOwnerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repoWrapper;
        private readonly IMapper _mapper;

        public IOwnerController(IRepositoryWrapper repoWrapper, IMapper mapper)
        {
            _repoWrapper = repoWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = _repoWrapper.Owner.FindAll();

            var dtos = _mapper.Map<IEnumerable<OwnerDto>>(items);

            return Ok(dtos.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var owner = _repoWrapper.Owner.FindById(id);

            if (owner == null) return NotFound();

            var dto = _mapper.Map<OwnerDto>(owner);

            return Ok(dto);
        }
    }
}
