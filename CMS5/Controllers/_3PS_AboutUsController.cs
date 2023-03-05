using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers.SectionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class _3PS_AboutUsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _3PS_AboutUsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        //------------------------------------------- GET by name about_us ------------------------------------------------
        //-------------------Get all about_us -------------------
        [HttpGet]
        public JsonResult Get_about_us()
        {
            //string name = "about_us";

            string query = @"
                select 
                        au.id as ""id"",
                        au.section_name as ""section_name"",
                        au.section_type as ""section_type"",
                        au.layout_position as ""layout_position"",
                        au.last_mod_date as ""last_mod_date"",
                        au.user_name as ""user_name"",
                        au.text as ""text"",
                        au.additional_text as ""additional_text"",
                        au.image1 as ""image1"",
                        au.image2 as ""image2"",
                        au.image3 as ""image3""   
                 from about_us as au
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


        //------------------- Get about_us by section_name -------------------

        [HttpGet("{section_name}")]
        public JsonResult GetAbout_UsByTitle(string section_name)
        {
            //string name = "about_us";
            string query = @"
                select 
                        au.id as ""hb.id"",
                        au.section_name as ""section_name"",
                        au.section_type as ""section_type"",
                        au.layout_position as ""layout_position"",
                        au.last_mod_date as ""last_mod_date"",
                        au.user_name as ""user_name"",
                        au.text as ""text"",
                        au.additional_text as ""additional_text"",
                        au.image1 as ""image1"",
                        au.image2 as ""image2"",
                        au.image3 as ""image3""  
                from about_us as au
                where au.section_name=@section_name
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

        ////------------------------------------------- POST by name about_us ------------------------------------------------
        [HttpPost]
        public JsonResult about_us(DB3_AboutUsDTO about_us)
        {
            int id = 0;
            string query = @"
                insert into about_us
                (id,section_name,section_type,layout_position,last_mod_date,user_name,text,additional_text,image1,image2,image3)
                values 
                (@id,@section_name,@section_type,@layout_position,@last_mod_date,@user_name,@text,@additional_text,@image1,@image2,@image3)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", about_us.id);
                    myCommand.Parameters.AddWithValue("@section_name", about_us.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", about_us.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", about_us.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", about_us.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", about_us.user_name);
                    myCommand.Parameters.AddWithValue("@text", about_us.text);
                    myCommand.Parameters.AddWithValue("@additional_text", about_us.additional_text);
                    myCommand.Parameters.AddWithValue("@image1", about_us.image1);
                    myCommand.Parameters.AddWithValue("@image2", about_us.image2);
                    myCommand.Parameters.AddWithValue("@image3", about_us.image3);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("New about_us Added Successfully");
        }


        ////------------------------------------------- PUT (update) IN about_us ------------------------------------------------

        [HttpPut]
        public JsonResult PutInAbout_us(DB3_AboutUsDTO about_us)
        {
            string query = @"
                update about_us
                set id = @id,
                section_name = @section_name,
                section_type = @section_type,
                layout_position = @layout_position,
                last_mod_date = @last_mod_date,
                user_name = @user_name,
                text = @text,
                additional_text = @additional_text,
                image1 = @image1,
                image2 = @image2,
                image3 = @image3

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
                    myCommand.Parameters.AddWithValue("@id", about_us.id);
                    myCommand.Parameters.AddWithValue("@section_name", about_us.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", about_us.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", about_us.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", about_us.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", about_us.user_name);
                    myCommand.Parameters.AddWithValue("@text", about_us.text);
                    myCommand.Parameters.AddWithValue("@additional_text", about_us.additional_text);
                    myCommand.Parameters.AddWithValue("@image1", about_us.image1);
                    myCommand.Parameters.AddWithValue("@image2", about_us.image2);
                    myCommand.Parameters.AddWithValue("@image3", about_us.image3);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("about_us Updated Successfully");
        }


        ////---------------------------------------------- Delete by Id and name(Baner) ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from about_us
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
            return new JsonResult("about_us Deleted Successfully");
        }


    }
}



