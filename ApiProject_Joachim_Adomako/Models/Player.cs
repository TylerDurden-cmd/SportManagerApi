using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiProject_Joachim_Adomako.Models
{
    public class Player
    {
        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column(name: "Name Player", TypeName = "varchar(32)")]
        [MaxLength(25)]
        public string Name { get; set; } = string.Empty;

        [Column(name: "Age Player")]
        public int Age { get; set; }

        [Column(name: "Team Id")]
        [Required]
        public int? Team_id { get; set; }

        [Column(name: "Team")]
        public Team? Team { get; set; }

        [Column(name: "Picture Player")]
        public string Image { get; set; } = string.Empty;
    }

}
