using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTO
{
    public class DB6_TestimonialsListDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        [Required]
        public int rating { get; set; }
        public string opinion { get; set; }
        public string author { get; set; }
        public string author_description { get; set; }

        [ForeignKey("testimonials")]
        public int testimonials_id { get; set; }
        public virtual DB6_TestimonialsDTO testimonials { get; set; }
    }
}

