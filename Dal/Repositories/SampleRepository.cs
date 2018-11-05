using Common.Model;
using Dal.Entities.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private readonly IMyFirstFullStackApp_DEVContext _context;

        public SampleRepository(IMyFirstFullStackApp_DEVContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TestModel>> GetTestsAsync()
        {
            var entites = await _context.Test.ToListAsync();
            // TODO use AutoMapper
            return entites.Select(e => new TestModel
            {
                Id = e.Id,
                Title = e.Title
            });
        }

        public async Task<TestModel> GetTestByIdAsync(int id)
        {
            var entity = await _context.Test.Where(t => t.Id == id).SingleOrDefaultAsync();
            // TODO use AutoMapper
            return new TestModel
            {
                Id = entity.Id,
                Title = entity.Title
            };
        }
    }
}
