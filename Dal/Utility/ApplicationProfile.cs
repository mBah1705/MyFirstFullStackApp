using AutoMapper;
using Common.Models;
using Dal.Entities;

namespace Common.Utility
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Test, TestModel>();
            CreateMap<Candidate, CandidateModel>()
                .ForMember(dest => dest.TestName, opt => opt.MapFrom(src => src.Test.Title));
        }
    }
}
