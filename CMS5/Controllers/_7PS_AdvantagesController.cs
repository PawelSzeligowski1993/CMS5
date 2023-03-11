using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace CMS_Projekt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class _7PS_AdvantagesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _7PS_AdvantagesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET ------------------------------------------------
        //-------------------Get all advantages -------------------
        [HttpGet]
        public JsonResult Get_All_Advantages()
        {
            string query = @"
                select 
                        a.id as ""id"",
                        a.section_name as ""section_name"",
                        a.section_type as ""section_type"",
                        a.layout_position as ""layout_position"",
                        a.last_mod_date as ""last_mod_date"",
                        a.user_name as ""user_name""
                 from advantages as a
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


        //------------------- Get advantages by title -------------------

        [HttpGet("{section_name}")]
        public JsonResult GetAdvantagesByTitle(string section_name)
        {

            string query = @"
                select 
                        a.id as ""id"",
                        a.section_name as ""section_name"",
                        a.section_type as ""section_type"",
                        a.layout_position as ""layout_position"",
                        a.last_mod_date as ""last_mod_date"",
                        a.user_name as ""user_name""
                 from advantages as a
                where (section_name=@section_name)
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

        ////------------------------------------------- POST by name advantages ------------------------------------------------
        [HttpPost]
        public JsonResult PostAdvantages(DB7_AdvantagesDTO advantages)
        {
            int id = 0;
            string query = @"
                insert into advantages
                (id,section_name,section_type,layout_position,last_mod_date,user_name)
                values 
                (@id,@section_name,@section_type,@layout_position,@last_mod_date,@user_name)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", advantages.id);
                    myCommand.Parameters.AddWithValue("@section_name", advantages.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", advantages.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", advantages.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", advantages.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", advantages.user_name);
                    //myCommand.Parameters.AddWithValue("@advantages_list_id", advantages.advantages_list_id);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("New advantages Added Successfully");
        }


        ////------------------------------------------- PUT (update) IN advantages ------------------------------------------------

        [HttpPut]
        public JsonResult PutInAdvantages(DB7_AdvantagesDTO advantages)
        {
            string query = @"
                update advantages
                set id = @id,
                section_name = @section_name,
                section_type = @section_type,
                layout_position = @layout_position,
                last_mod_date = @last_mod_date,
                user_name = @user_name
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
                    myCommand.Parameters.AddWithValue("@id", advantages.id);
                    myCommand.Parameters.AddWithValue("@section_name", advantages.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", advantages.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", advantages.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", advantages.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", advantages.user_name);
                    //myCommand.Parameters.AddWithValue("@advantages_list_id", advantages.advantages_list_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("advantages Updated Successfully");
        }


        ////---------------------------------------------- Delete advantages by Id ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult DeleteAdvantages(int id)
        {
            string query = @"
                delete from advantages
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
            return new JsonResult("advantages Deleted Successfully");
        }
    }
}
