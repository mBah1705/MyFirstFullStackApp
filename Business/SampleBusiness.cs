using Common.Model;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private void InstantiateSample() => sample = _sampleRepository.CreateSampleData();


        public IEnumerable<string> ListAllData()
        {
            var list = new List<string>();
            InstantiateSample();
            foreach (TestModel data in sample)
            {
                list.Add(data.Title);
            }
            return list;
        }

        public string ListOneData(int id)
        {
            InstantiateSample();
            return sample.Where(data => data.Id == id).FirstOrDefault().Title;
        }
    }
}
