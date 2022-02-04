using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;
using API.Models;
using AutoMapper;

namespace API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.CityOfResidence,
                    src => src.MapFrom(src => src.CityOfResidence.Name))
                .ForMember(dest => dest.LivingCity,
                    src => src.MapFrom(src => src.LivingCity.Name))
                .ForMember(dest => dest.FamilyPosition,
                    src => src.MapFrom(src => src.FamilyPosition.Name))
                .ForMember(dest => dest.Citizen,
                    src => src.MapFrom(src => src.Citizen.Name))
                .ForMember(dest => dest.Invalidity,
                    src => src.MapFrom(src => src.Invalidity.Name));
                  
            CreateMap<ClientDto, Client>()
                .ForMember(dest => dest.CityOfResidence,
                    src => src.MapFrom(src => new City { Name = src.CityOfResidence }))
                .ForMember(dest => dest.LivingCity,
                    src => src.MapFrom(src => new City { Name = src.LivingCity }))
                .ForMember(dest => dest.FamilyPosition,
                    src => src.MapFrom(src => new FamilyPosition { Name = src.FamilyPosition }))
                .ForMember(dest => dest.Citizen,
                    src => src.MapFrom(src => new Country { Name = src.Citizen }))
                .ForMember(dest => dest.Invalidity,
                    src => src.MapFrom(src => new Invalidity { Name = src.Invalidity }));;
        }
    }
}