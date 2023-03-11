using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace CMS_Projekt_API.Controllers
{
    
 
    [Route("api/[controller]")]
    [ApiController]
    public class _6PS_TestimonialsListController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _6PS_TestimonialsListController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET ------------------------------------------------
        //-------------------Get all TestimonialsList -------------------
        [HttpGet]
        public JsonResult Get_All_TestimonialsList()
        {


            string query = @"
                select 
                        test_li.id as ""test_li.id"",
                        test_li.rating as ""test_li.rating"",
                        test_li.opinion as ""test_li.opinion"",
                        test_li.author as ""test_li.author"",
                        test_li.author_description as ""test_li.author_description"",
                        test_li.testimonials_id as ""test_li.testimonials_id""
                 from testimonials_list as test_li
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }


        //------------------- Get TestimonialsList by author_description -------------------

        [HttpGet("{author}")]
        public JsonResult GetTestimonialsListByTitle(string author)
        {

            string query = @"
                select 
                        test_li.id as ""test_li.id"",
                        test_li.rating as ""test_li.rating"",
                        test_li.opinion as ""test_li.opinion"",
                        test_li.author as ""test_li.author"",
                        test_li.author_description as ""test_li.author_description"",
                        test_li.testimonials_id as ""test_li.testimonials_id""
                 from testimonials_list as test_li
                where (author=@author)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@author", author);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        ////------------------------------------------- POST by name TestimonialsList ------------------------------------------------
        [HttpPost]
        public JsonResult PostTestimonialsList(DB6_TestimonialsListDTO testimonialsList)
        {
            int id = 0;
            string query = @"
                insert into testimonials_list
                (id,rating,opinion,author,author_description,testimonials_id)
                values 
                (@id,@rating,@opinion,@author,@author_description,@testimonials_id)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", testimonialsList.id);
                    myCommand.Parameters.AddWithValue("@rating", testimonialsList.rating);
                    myCommand.Parameters.AddWithValue("@opinion", testimonialsList.opinion);
                    myCommand.Parameters.AddWithValue("@author", testimonialsList.author);
                    myCommand.Parameters.AddWithValue("@author_description", testimonialsList.author_description);
                    myCommand.Parameters.AddWithValue("@testimonials_id", testimonialsList.testimonials_id);
                    //myCommand.Parameters.AddWithValue("@services_list_id", services.services_list_id);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("New TestimonialsList Added Successfully");
        }


        ////------------------------------------------- PUT (update) IN TestimonialsList ------------------------------------------------

        [HttpPut]
        public JsonResult PutInServices(DB6_TestimonialsListDTO testimonialsList)
        {
            string query = @"
                update testimonials_list
                        set id = @id,
                        rating = @rating,
                        opinion = @opinion,
                        author = @author,
                        author_description = @author_description,
                        testimonials_id = @testimonials_id
                where (id = @id) 
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", testimonialsList.id);
                    myCommand.Parameters.AddWithValue("@rating", testimonialsList.rating);
                    myCommand.Parameters.AddWithValue("@opinion", testimonialsList.opinion);
                    myCommand.Parameters.AddWithValue("@author", testimonialsList.author);
                    myCommand.Parameters.AddWithValue("@author_description", testimonialsList.author_description);
                    myCommand.Parameters.AddWithValue("@testimonials_id", testimonialsList.testimonials_id);
                    //myCommand.Parameters.AddWithValue("@services_list_id", services.services_list_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("TestimonialsList Updated Successfully");
        }


        ////---------------------------------------------- Delete TestimonialsList by Id ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult DeleteTestimonialsList(int id)
        {
            string query = @"
                delete from testimonials_list
                where (id=@id );
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }
            return new JsonResult("TestimonialsList Deleted Successfully");
        }

    }
}
