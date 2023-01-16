using Microsoft.AspNetCore.Mvc;
using TaskManager.Service;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly AssignmentService _service;

        public AssignmentController(AssignmentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<List<AssignmentViewModel>> GetAsync()
        {
            return await _service.GetAsync();
        }
    }
}
