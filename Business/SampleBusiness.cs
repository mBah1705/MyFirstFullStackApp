using Common.Model;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business
{
    public class SampleBusiness : ISampleBusiness
    {
        private readonly ISampleRepository _sampleRepository;
        private IEnumerable<TestModel> sample;
        private TestModel singleSample;

        public SampleBusiness(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public async Task<IEnumerable<string>> ListAllTestsAsync()
        {
            await InstantiateSampleAsync();
            return sample.Select(e => e.Title);
        }

        public async Task<string> ListOneTestAsync(int id)
        {
            string title = null;

            try
            {
                await InstantiateSampleAsync(id);
                title = singleSample.Title;
            }
            catch (NullReferenceException)
            {
                // NullReferenceException will be caught when the ID is not found!
            }

            return title;
        }

        private async Task InstantiateSampleAsync()
        {
            sample = await _sampleRepository.GetTestsAsync();
        }

        private async Task InstantiateSampleAsync(int id)
        {
            singleSample = await _sampleRepository.GetTestByIdAsync(id);
        }
    }
}
