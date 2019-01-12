using Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business
{
    public interface ICandidatesBusiness
    {
        Task<IEnumerable<CandidateWithResultModel>> GetCandidatesAsync();
        Task<double> GetCandidatesAverageAsync();
        Task<double> GetCandidatesStantdardDeviationAsync();
    }
}