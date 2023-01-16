using TaskManager.Repository;
using TaskManager.ViewModels;

namespace TaskManager.Service
{
    public class AssignmentService
    {
        private readonly AssignmentRepository _assignmentRepository;
        public AssignmentService(AssignmentRepository assignmentRepository) {
            _assignmentRepository = assignmentRepository;
        }

        public async Task<List<AssignmentViewModel>> GetAsync()
        {
            var dto = await _assignmentRepository.GetAsync();

            var assignments = new List<AssignmentViewModel>();

            foreach(var obj in dto)
            {
                assignments.Add(new AssignmentViewModel
                {
                    Archived = obj.Archived,
                    Assignee = obj.Member.FirstName + " " + obj.Member.LastName,
                    Description = obj.Description,
                    DueDate = obj.DueDate
                });
            }

            return assignments;
        }
    }
}
