using AutoMapper;
using Common.Model;
using Dal.Entities.DB;

namespace Common.Utility
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Test, TestModel>();
        }
    }
}
