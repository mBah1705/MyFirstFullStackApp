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
        public SampleBusiness(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        private async Task InstantiateSample()
        {
            sample = await _sampleRepository.GetTestsAsync();
        }

        public async Task<IEnumerable<string>> ListAllTestsAsync()
        {
            var list = new List<string>();
            await InstantiateSample();
            foreach (TestModel data in sample)
            {
                await Task.Run(() => list.Add(data.Title));
            }
            return list;
        }

        public async Task<string> ListOneTestAsync(int id)
        {
            await InstantiateSample();

            var testSample = sample.ElementAtOrDefault(id);

            if (testSample != null)
            {
                return await Task.Run(() => sample.Where(test => test.Id == id).FirstOrDefault().Title);
            }
            else
            {
                throw new Exception($"ID: {id} is not found!");
            }
        }
    }
}
