using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class DB7_AdvantagesDTO
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

        [ForeignKey("advantages_list")]
        public int advantages_list_id { get; set; }
        public DB7_AdvantagesListDTO advantages_list { get; set; }
    }
}
