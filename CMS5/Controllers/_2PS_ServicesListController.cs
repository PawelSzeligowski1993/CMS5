using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace CMS5.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class _2PS_ServicesListController : Controller
    {
        private readonly IConfiguration _configuration;
        public _2PS_ServicesListController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        //------------------------------------------- GET ------------------------------------------------
        //-------------------Get all services_list -------------------
        [HttpGet]
        public JsonResult Get_All_Services_List()
        {


            string query = @"
                select 
                        serv_li.id as ""serv_li.id"",
                        serv_li.text as ""serv_li.text"",
                        serv_li.additional_text as ""serv_li.additional_text"",
                        serv_li.baner_section_name as ""serv_li.baner_section_name"",
                        serv_li.services_id as ""serv_li.services_id""
                 from services_list as serv_li
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


        //------------------- Get services_list by title -------------------

        [HttpGet("{baner_section_name}")]
        public JsonResult GetServicesListByTitle(string baner_section_name)
        {

            string query = @"
                select 
                        serv_li.id as ""serv_li.id"",
                        serv_li.text as ""serv_li.text"",
                        serv_li.additional_text as ""serv_li.additional_text"",
                        serv_li.baner_section_name as ""serv_li.baner_section_name"",
                        serv_li.services_id as ""serv_li.services_id""
                 from services_list as serv_li
                where (baner_section_name=@baner_section_name)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@baner_section_name", baner_section_name);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        ////------------------------------------------- POST by name services_list ------------------------------------------------
        [HttpPost]
        public JsonResult PostServices(DB2_ServicesListDTO services_list)
        {
            int id = 0;
            string query = @"
                insert into services_list
                (id,text,additional_text,baner_section_name,services_id)
                values 
                (@id,@text,@additional_text,@baner_section_name,@services_id)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", services_list.id);
                    myCommand.Parameters.AddWithValue("@text", services_list.text);
                    myCommand.Parameters.AddWithValue("@additional_text", services_list.additional_text);
                    myCommand.Parameters.AddWithValue("@baner_section_name", services_list.baner_section_name);
                    myCommand.Parameters.AddWithValue("@services_id", services_list.services_id);

                    //myCommand.Parameters.AddWithValue("@services_list_id", services.services_list_id);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("New services_list Added Successfully");
        }


        ////------------------------------------------- PUT (update) IN services_list ------------------------------------------------

        [HttpPut]
        public JsonResult PutInServices(DB2_ServicesListDTO services_list)
        {
            string query = @"
                update services_list
                set id = @id,
                text = @text,
                additional_text = @additional_text,
                baner_section_name = @baner_section_name,
                services_id = @services_id
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
                    myCommand.Parameters.AddWithValue("@id", services_list.id);
                    myCommand.Parameters.AddWithValue("@text", services_list.text);
                    myCommand.Parameters.AddWithValue("@additional_text", services_list.additional_text);
                    myCommand.Parameters.AddWithValue("@baner_section_name", services_list.baner_section_name);
                    myCommand.Parameters.AddWithValue("@services_id", services_list.services_id);
                    //myCommand.Parameters.AddWithValue("@services_list_id", services.services_list_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("services_list Updated Successfully");
        }


        ////---------------------------------------------- Delete services_list by Id ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult DeleteServicesList(int id)
        {
            string query = @"
                delete from services_list
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
            return new JsonResult("services_list Deleted Successfully");
        }

    }
}
