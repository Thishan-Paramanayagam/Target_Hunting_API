using System.ComponentModel.DataAnnotations;

namespace Target_Hunting_API.Models
{
    public class Candidate
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
}
