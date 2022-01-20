namespace SchoolApp.Models
{
    public class Student : Entity
    {
        public int SchoolId { get; set; }
        public School School { get; set; }
        public int SexId { get; set; }
        public Sex Sex { get; set; }
    }
}
