using Common.Model;
using Dal.Entities.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        MyFirstFullStackApp_DEVContext context = new MyFirstFullStackApp_DEVContext();

        public async Task<IEnumerable<TestModel>> GetTestsAsync()
        {
            var tests = context.Test;
            var output = new List<TestModel>();
            var tasks = new List<Task<TestModel>>();

            foreach (var test in tests)
            {
                tasks.Add(Task.Run(() => new TestModel { Id = test.Id, Title = test.Title }));
            }

            var results = await Task.WhenAll(tasks);

            foreach( var item in results)
            {
                output.Add(item);
            }

            return output;
        }
    }
}
