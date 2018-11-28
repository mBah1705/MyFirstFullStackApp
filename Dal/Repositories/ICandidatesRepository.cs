using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models;

namespace Dal.Repositories
{
    public interface ICandidatesRepository
    {
        Task<IEnumerable<CandidateModel>> GetCandidatesAsync();
    }
}