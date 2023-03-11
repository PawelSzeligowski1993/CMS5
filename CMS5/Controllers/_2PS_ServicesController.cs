using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace CMS_Projekt_API.Controllers
{
    
 
    [Route("api/[controller]")]
    [ApiController]
    public class _2PS_ServicesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _2PS_ServicesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET ------------------------------------------------
        //-------------------Get all services -------------------
        [HttpGet]
        public JsonResult Get_All_Services()
        {


            string query = @"
                select 
                        serv.id as ""id"",
                        serv.section_name as ""section_name"",
                        serv.section_type as ""section_type"",
                        serv.layout_position as ""layout_position"",
                        serv.last_mod_date as ""last_mod_date"",
                        serv.user_name as ""user_name"",  
                        serv.text as ""text""
                 from services as serv
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


        //------------------- Get services by title -------------------

        [HttpGet("{section_name}")]
        public JsonResult GetServicesByTitle(string section_name)
        {

            string query = @"
                select 
                        serv.id as ""id"",
                        serv.section_name as ""section_name"",
                        serv.section_type as ""section_type"",
                        serv.layout_position as ""layout_position"",
                        serv.last_mod_date as ""last_mod_date"",
                        serv.user_name as ""user_name"",  
                        serv.text as ""text""
                 from services as serv
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



        ////------------------------------------------- POST by name services ------------------------------------------------
        [HttpPost]
        public JsonResult PostServices(DB2_ServicesDTO services)
        {
            int id = 0;
            string query = @"
                insert into services
                (id,section_name,section_type,layout_position,last_mod_date,user_name,text)
                values 
                (@id,@section_name,@section_type,@layout_position,@last_mod_date,@user_name,@text)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", services.id);
                    myCommand.Parameters.AddWithValue("@section_name", services.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", services.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", services.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", services.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", services.user_name);
                    myCommand.Parameters.AddWithValue("@text", services.text);
                    //myCommand.Parameters.AddWithValue("@services_list_id", services.services_list_id);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("New services Added Successfully");
        }


        ////------------------------------------------- PUT (update) IN services ------------------------------------------------

        [HttpPut]
        public JsonResult PutInServices(DB2_ServicesDTO services)
        {
            string query = @"
                update services
                set id = @id,
                section_name = @section_name,
                section_type = @section_type,
                layout_position = @layout_position,
                last_mod_date = @last_mod_date,
                user_name = @user_name,
                text = @text
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
                    myCommand.Parameters.AddWithValue("@id", services.id);
                    myCommand.Parameters.AddWithValue("@section_name", services.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", services.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", services.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", services.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", services.user_name);
                    myCommand.Parameters.AddWithValue("@text", services.text);
                    //myCommand.Parameters.AddWithValue("@services_list_id", services.services_list_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("services Updated Successfully");
        }


        ////---------------------------------------------- Delete Services by Id ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult DeleteServices(int id)
        {
            string query = @"
                delete from services
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
            return new JsonResult("services Deleted Successfully");
        }

    }
}
