using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiProject_Joachim_Adomako.Models
{
    public class Match 
    {
        [Column("Id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column(name: "Team Id 1", TypeName = "varchar(32)")]
        [Required]
        public int? Team1_id { get; set; }
        [Column(name: "Team 1", TypeName = "varchar(32)")]
        public Team? Team1 { get; set; }

        [Column(name: "Team Id 2", TypeName = "varchar(32)")]
        [Required]
        public int? Team2_id { get; set; }
        [Column(name: "Team 2", TypeName = "varchar(32)")]
        public Team? Team2 { get; set; }

        [Column(name: "Date")]
        public DateTime Date { get; set; }

        [Column(name: "Location")]
        public string Location { get; set; } = string.Empty;

        [Column(name: "Outcome")] 
        public string Outcome { get; set; } = string.Empty;

        [Column(name: "Image")]
        public string Image { get; set; } = string.Empty;
    }

}
