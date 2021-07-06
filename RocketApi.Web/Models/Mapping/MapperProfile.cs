using AutoMapper;
using RocketApi.Entities.Models;
using RocketApi.Web.Models.DTOs;

namespace RocketApi.Web.Models.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Owner, OwnerDto>();
        }
    }
}
