namespace TaskMangeSystem.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string role { get; set; }
        public ICollection<task> tasks { get; set; }
    }
}
