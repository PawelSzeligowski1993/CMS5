using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class DB5_WorkWithUsDTO
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
        public string additional_text { get; set; }
        public string background_image { get; set; }
    }
}


