using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMangeSystem.Models
{
    public class task
    {
        public int id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string status { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
        public int  TeamMemberid {  get; set; }
        [ForeignKey("TeamMemberid")]
        public TeamMember TeamMember { get; set; }


    }
}
