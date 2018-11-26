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

        public SampleBusiness(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public async Task<IEnumerable<string>> GetTestsAsync()
        {
            IEnumerable<TestModel> sample = await _sampleRepository.GetTestsAsync();
            return sample.Select(e => e.Title);
        }

        public async Task<string> GetTestByIdAsync(int id)
        {
            string title = null;

            try
            {
                TestModel singleSample = await _sampleRepository.GetTestByIdAsync(id);
                title = singleSample.Title;
            }
            catch (NullReferenceException)
            {
                // NullReferenceException will be caught when the ID is not found!
            }

            return title;
        }
    }
}
