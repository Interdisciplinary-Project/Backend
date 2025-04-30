using AutoMapper;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;

namespace EscoteiroLMS.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Responsible, ResponsibleDto>().ReverseMap();
            CreateMap<Branch, BranchDto>().ReverseMap();
        }

    }
}
