using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMangeSystem.Models.viewModel
{
    public class Taskviewmodel
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
   
        public int TeamMemberid { get; set; }
        public ICollection<TeamMember> teams { get; set; }
        public ICollection<Project> projects { get; set; }
  
 
    }
}
