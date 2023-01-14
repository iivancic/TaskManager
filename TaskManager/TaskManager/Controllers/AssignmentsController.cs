using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;
using TaskManager.Repository;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentsController : ControllerBase
    {
        private readonly Repository.AssignmentRepository _repository;

        public AssignmentsController(AssignmentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Assignment>> GetAsync()
        {
            return await _repository.GetAsync();
        }
    }
}
