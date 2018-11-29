using AutoMapper;
using Common.Models;
using Dal.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dal.Repositories
{
    public class CandidatesRepository : ICandidatesRepository
    {
        private readonly IMyFirstFullStackApp_DEVContext _context;
        private readonly IMapper _mapper;

        public CandidatesRepository(IMyFirstFullStackApp_DEVContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CandidateModel>> GetCandidatesAsync()
        {
            var entities = await _context.Candidate
                .Include(c => c.Test)
                .Include(c => c.Result)
                    .ThenInclude(r => r.Answer)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CandidateModel>>(entities);
        }
    }
}
