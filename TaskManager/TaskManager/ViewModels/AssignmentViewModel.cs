namespace TaskManager.ViewModels
{
    public class AssignmentViewModel
    {
        public enum Status
        {
            None,
            InProgress,
            Done
        }
        public string Description { get; set; }
        public bool Archived { get; set; }
        public DateTime DueDate { get; set; }
        public string Assignee { get; set; }

    }
}
