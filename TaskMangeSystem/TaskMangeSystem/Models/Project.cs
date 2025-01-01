namespace TaskMangeSystem.Models
{
    public class Project
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<task> tasks { get; set; }

    }
}
