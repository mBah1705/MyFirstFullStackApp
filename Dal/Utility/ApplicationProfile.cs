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
            CreateMap<Candidate, CandidateModel>();
        }
    }
}
