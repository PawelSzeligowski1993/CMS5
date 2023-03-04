using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class DB4_NumbersDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public string section_name { get; set; }
        public string section_type { get; set; }
        public int layout_position { get; set; }
        public DateTime last_mod_date { get; set; }
        public string user_name { get; set; }
        public string text { get; set; }
        public string value1 { get; set; }
        public string description1 { get; set; }
        public string value2 { get; set; }
        public string description2 { get; set; }
    }
}

