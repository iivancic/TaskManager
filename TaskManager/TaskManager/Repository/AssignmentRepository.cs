using Microsoft.EntityFrameworkCore;
using TaskManager.Context;
using TaskManager.Models;

namespace TaskManager.Repository
{
    public class AssignmentRepository
    {
        private readonly AssignmentContext _context;
        
        public AssignmentRepository(AssignmentContext context)
        {
            _context = context;
        }

        public Task<List<Assignment>> GetAsync()
        {
            return _context.Tasks.Include(x => x.Member).ToListAsync();
        }
    }
}
