using AutoMapper;
using Common.Models;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class CandidatesBusiness : ICandidatesBusiness
    {
        private readonly ICandidatesRepository _candidatesRepository;
        private readonly IMapper _mapper;

        public CandidatesBusiness(ICandidatesRepository candidatesRepository, IMapper mapper)
        {
            _candidatesRepository = candidatesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateWithResultModel>> GetCandidatesAsync()
        {
            return await GetAndConvertCandidatesAsync();
        }

        public async Task<double> GetCandidatesAverageAsync()
        {
            return await CalculateCandidatesAverage();
        }

        public async Task<double> GetCandidatesStantdardDeviationAsync()
        {
            IEnumerable<CandidateWithResultModel> candidates = await GetAndConvertCandidatesAsync();
            double average = await CalculateCandidatesAverage();
            IEnumerable<int> scoresArray = candidates.Select(c => c.Score);
            double sumOfSquareDifferences = scoresArray.Select(s => Math.Pow(s - average, 2)).Sum();
            double sd = Math.Sqrt(sumOfSquareDifferences / scoresArray.Count());

            return sd;
        }

        private async Task<IEnumerable<CandidateWithResultModel>> GetAndConvertCandidatesAsync()
        {
            IEnumerable<CandidateModel> candidates = await _candidatesRepository.GetCandidatesAsync();
            return _mapper.Map<IEnumerable<CandidateWithResultModel>>(candidates);
        }

        private async Task<double> CalculateCandidatesAverage()
        {
            IEnumerable<CandidateWithResultModel> candidates = await GetAndConvertCandidatesAsync();
            return candidates.Average(c => c.Score);
        }
    }
}
