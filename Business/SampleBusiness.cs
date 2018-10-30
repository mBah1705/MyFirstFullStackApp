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

        private async Task InstantiateSampleAsync()
        {
            sample = await _sampleRepository.GetTestsAsync();
        }

        public async Task<IEnumerable<string>> ListAllTestsAsync()
        {
            var list = new List<string>();
            await InstantiateSampleAsync();
            foreach (TestModel data in sample)
            {
                await Task.Run(() => list.Add(data.Title));
            }
            return list;
        }

        public async Task<string> ListOneTestAsync(int id)
        {
            await InstantiateSampleAsync();

            string result = null;

            try
            {
                result = sample.Where(t => t.Id == id).FirstOrDefault().Title;
                result = await Task.Run(() => result);
            }
            catch (NullReferenceException)
            {
                // NullReferenceException will be caught when the ID is not found!
            }
            return result;
        }
    }
}
