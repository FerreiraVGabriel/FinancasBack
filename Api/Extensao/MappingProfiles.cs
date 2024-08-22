using Api.Dtos.Input;
using Api.Dtos.Output;
using AutoMapper;
using Infra.Entities;

namespace Api.Extensao
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //USER

            CreateMap<User, UserOutputDTO>();
            CreateMap<UserInputDTO, User>();
        }
    }
}
