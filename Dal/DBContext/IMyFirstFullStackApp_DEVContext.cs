using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.DBContext
{
    public interface IMyFirstFullStackApp_DEVContext
    {
        DbSet<Answer> Answer { get; set; }
        DbSet<Candidate> Candidate { get; set; }
        DbSet<Question> Question { get; set; }
        DbSet<Result> Result { get; set; }
        DbSet<Test> Test { get; set; }
        DbSet<TestQuestion> TestQuestion { get; set; }
    }
}