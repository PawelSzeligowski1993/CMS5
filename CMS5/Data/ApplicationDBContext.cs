using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplication1.Models;
using WebApplication1.Models.DTO;

namespace WebApplication1.Data
{
    public class ApplicationDBContext : DbContext
    {
        

        public DbSet<DB1_HeroBannerDTO> hero_banners { get; set; }
        public DbSet<DB2_ServicesDTO> services { get; set; }
        public DbSet<DB2_ServicesListDTO> services_list { get; set; }
        public DbSet<DB3_AboutUsDTO> about_us { get; set; }
        public DbSet<DB4_NumbersDTO> numbers { get; set; }
        public DbSet<DB5_WorkWithUsDTO> work_with_us { get; set; }
        public DbSet<DB6_TestimonialsDTO> testimonials { get; set; }
        public DbSet<DB6_TestimonialsListDTO> testimonials_list { get; set; }
        public DbSet<DB7_AdvantagesDTO> advantages { get; set; }
        public DbSet<DB7_AdvantagesListDTO> advantages_list { get; set; }


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)

        {

        }

    }
}
