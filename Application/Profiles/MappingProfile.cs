using Application.DTOs.Certification;
using Domain.Entities;

using AutoMapper;
using Application.DTOs.Education;
using Application.DTOs.Experience;
using Application.DTOs.Project;
using Application.DTOs.Skill;
using HR.LeaveManagement.Application.DTOs.Interest;
using Application.DTOs.Language;
using Application.DTOs.SocialNetwork;
using Domain.Entities.Identity;
using Application.DTOs.User;
using Application.DTOs.Info;

namespace Application.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Certification, CertificationDto>().ReverseMap();
            CreateMap<Certification,CreateCertificationDto>().ReverseMap();
            CreateMap<Education, EducationDto>().ReverseMap();
            CreateMap<Experience, ExperienceDto>().ReverseMap();
            CreateMap<Language, LanguageDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Skill, SkillDto>().ReverseMap();
            CreateMap<Interest, InterestDto>().ReverseMap();
            CreateMap<SocialNetwork , SocialNetworkDto>().ReverseMap();
            CreateMap<User, CreateUserDetailDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, DevDto>().ReverseMap();
            CreateMap<Info, InfoDto>().ReverseMap();


        }
       

    }
}
