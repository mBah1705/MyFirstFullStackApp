using AutoMapper;
using Common.Models;
using Dal.Entities;
using System.Linq;

namespace Common.Utility
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Test, TestModel>();
            CreateMap<Candidate, CandidateModel>();
            CreateMap<CandidateModel, CandidateWithResultModel>()
                .ForMember(dest => dest.TestTitle, opt => opt.MapFrom(src => src.Test.Title))
                .ForMember(dest => dest.Score, opt => opt.MapFrom(src =>
                    (src.Result.ToList().Count(result => result.Answer.IsGood == true) * 20 /
                        src.Result.ToList().Count())));
        }
    }
}
