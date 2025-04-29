using AutoMapper;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Responsible, ResponsibleDto>().ForMember(dest => dest, config => config.Ignore()).ReverseMap();
        }

    }
}
