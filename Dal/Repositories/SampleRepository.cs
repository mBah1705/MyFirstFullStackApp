﻿using AutoMapper;
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
        private readonly IMapper _mapper;

        public SampleRepository(IMyFirstFullStackApp_DEVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TestModel>> GetTestsAsync()
        {
            var entites = await _context.Test.ToListAsync();
            return _mapper.Map<IEnumerable<TestModel>>(entites);
        }

        public async Task<TestModel> GetTestByIdAsync(int id)
        {
            var entity = await _context.Test.Where(t => t.Id == id).SingleOrDefaultAsync();
            return _mapper.Map<TestModel>(entity);
        }
    }
}
