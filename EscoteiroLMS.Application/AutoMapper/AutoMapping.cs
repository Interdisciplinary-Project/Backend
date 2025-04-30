using AutoMapper;
using EscoteiroLMS.Communication.Dto;
using EscoteiroLMS.Domain.Entities;
using EscoteiroLMS.Domain.ValueObjects;

namespace EscoteiroLMS.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Responsible, ResponsibleDto>().ReverseMap();
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<Scout, ScoutDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
        }

    }
}
