namespace TaskManager.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public bool Archived { get; set; }
        public DateTime DueDate { get; set; }
        public int Urgency { get; set; }
    }
}
