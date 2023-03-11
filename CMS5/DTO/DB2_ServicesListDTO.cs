using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class DB2_ServicesListDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public string text { get; set; }
        public string additional_text { get; set; }
        public string baner_section_name { get; set; }

        [ForeignKey("services")]
        public int services_id { get; set; }
        public virtual DB2_ServicesDTO services { get; set; }
    }
}
