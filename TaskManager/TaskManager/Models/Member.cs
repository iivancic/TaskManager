﻿namespace TaskManager.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Assignment>  Tasks { get; set; }
    }
}
