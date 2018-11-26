using AutoMapper;
using Common.Model;
using Dal.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class SampleRepository : ISampleRepository
    {
        private readonly IMyFirstFullStackApp_DEVContext _context;
        private readonly IMapper _mapper;

        public SampleRepository(IMyFirstFullStackApp_DEVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestModel>> GetTestsAsync()
        {
            var entities = await _context.Test.ToListAsync();
            return _mapper.Map<IEnumerable<TestModel>>(entities);
        }

        public async Task<TestModel> GetTestByIdAsync(int id)
        {
            var entity = await _context.Test.SingleOrDefaultAsync(t => t.Id == id);
            return _mapper.Map<TestModel>(entity);
        }
    }
}
