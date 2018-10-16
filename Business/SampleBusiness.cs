using Common.Model;
using Dal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class SampleBusiness
    {
        IEnumerable<TestModel> sample = SampleRepository.CreateSampleData();

        public IEnumerable<string> ListAllData()
        {
            var list = new List<string>();
            foreach (TestModel data in sample)
            {
                list.Add(data.Title);
            }
            return list;
        }

        public string ListOneData(int id)
        {
            return sample.Where(data => data.Id == id).FirstOrDefault().Title;
        }
    }
}
