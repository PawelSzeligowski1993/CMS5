using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace CMS4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _5PS_WorkWithUsController : Controller
    {
        private readonly IConfiguration _configuration;
        public _5PS_WorkWithUsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET work_with_us ------------------------------------------------
        //-------------------Get all numbers -------------------
        [HttpGet]
        public JsonResult GetWorkWithUs()
        {
            string query = @"
                select 
                        wwu.id as ""id"",
                        wwu.section_name as ""section_name"",
                        wwu.section_type as ""section_type"",
                        wwu.layout_position as ""layout_position"",
                        wwu.last_mod_date as ""last_mod_date"",
                        wwu.user_name as ""user_name"",
                        wwu.text as ""text"",
                        wwu.additional_text as ""additional_text"",
                        wwu.background_image as ""background_image""   
                from work_with_us as wwu
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


        //------------------- Get work_with_us by section_name -------------------

        [HttpGet("{section_name}")]
        public JsonResult GetNumbersByTitle(string section_name)
        {
            //string name = "numbers";
            string query = @"
                select 
                        wwu.id as ""id"",
                        wwu.section_name as ""section_name"",
                        wwu.section_type as ""section_type"",
                        wwu.layout_position as ""layout_position"",
                        wwu.last_mod_date as ""last_mod_date"",
                        wwu.user_name as ""user_name"",
                        wwu.text as ""text"",
                        wwu.additional_text as ""additional_text"",
                        wwu.background_image as ""background_image""  
                from work_with_us as wwu
                where wwu.section_name=@section_name
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@section_name", section_name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        ////------------------------------------------- POST work_with_us ------------------------------------------------
        [HttpPost]
        public JsonResult PostWorkWithUs(DB5_WorkWithUsDTO work_with_us)
        {
            string query = @"
                insert into work_with_us
                (id,section_name,section_type,layout_position,last_mod_date,user_name,text,additional_text,background_image)
                values 
                ((select max (id) from work_with_us) + 1,@section_name,@section_type,@layout_position,@last_mod_date,@user_name,@text,@additional_text,@background_image)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    //myCommand.Parameters.AddWithValue("@id", work_with_us.id);
                    myCommand.Parameters.AddWithValue("@section_name", work_with_us.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", work_with_us.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", work_with_us.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", work_with_us.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", work_with_us.user_name);
                    myCommand.Parameters.AddWithValue("@text", work_with_us.text);
                    myCommand.Parameters.AddWithValue("@additional_text", work_with_us.additional_text);
                    myCommand.Parameters.AddWithValue("@background_image", work_with_us.background_image);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("New work_with_us Added Successfully");
        }


        ////------------------------------------------- PUT (update) IN work_with_us ------------------------------------------------

        [HttpPut]
        public JsonResult PutInNumbers(DB5_WorkWithUsDTO work_with_us)
        {
            string query = @"
                update work_with_us
                set id = @id,
                section_name = @section_name,
                section_type = @section_type,
                layout_position = @layout_position,
                last_mod_date = @last_mod_date,
                user_name = @user_name,
                text = @text,
                additional_text = @additional_text,
                background_image = @background_image
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
                    myCommand.Parameters.AddWithValue("@id", work_with_us.id);
                    myCommand.Parameters.AddWithValue("@section_name", work_with_us.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", work_with_us.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", work_with_us.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", work_with_us.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", work_with_us.user_name);
                    myCommand.Parameters.AddWithValue("@text", work_with_us.text);
                    myCommand.Parameters.AddWithValue("@additional_text", work_with_us.additional_text);
                    myCommand.Parameters.AddWithValue("@background_image", work_with_us.background_image);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("work_with_us Updated Successfully");
        }


        ////---------------------------------------------- Delete work_with_us by Id ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult DeleteNumbers(int id)
        {
            string query = @"
                delete from work_with_us
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
            return new JsonResult("work_with_us Deleted Successfully");
        }


    }
}
