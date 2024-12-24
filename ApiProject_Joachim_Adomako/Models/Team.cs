using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiProject_Joachim_Adomako.Models
{
    public class Team
    {
        [Column("Id")]
        [Required]
        [Key]
        public int Id { get; set; }

        [Column(name: "Name Team", TypeName= "varchar(32)" )]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column(name: "Sport Team")]
        [Required]
        public string Sport { get; set; } = string.Empty;

        [Column(name: "City Team")]
        public string City { get; set; } = string.Empty;

        [Column(name: "Name Coach")]
        public string Coach { get; set; } = string.Empty;

        [Column(name: "Image Team")]
        public string Image { get; set; } = string.Empty;
    }

}
