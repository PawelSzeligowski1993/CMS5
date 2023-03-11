using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace CMS_Projekt_API.Controllers
{
    
 
    [Route("api/[controller]")]
    [ApiController]
    public class _7PS_AdvantagesListController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _7PS_AdvantagesListController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET ------------------------------------------------
        //-------------------Get all advantagesList -------------------
        [HttpGet]
        public JsonResult Get_All_Services()
        {


            string query = @"
                select 
                        adv_li.id as ""adv_li.id"",
                        adv_li.text as ""adv_li.text"",
                        adv_li.additional_text as ""adv_li.additional_text"",
                        adv_li.icon_url as ""adv_li.icon_url"",
                        adv_li.advantages_id as ""adv_li.advantages_id""
                 from advantages_list as adv_li
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


        //------------------- Get advantagesList by title -------------------

        [HttpGet("{text}")]
        public JsonResult GetServicesByTitle(string text)
        {

            string query = @"
                select 
                        adv_li.id as ""adv_li.id"",
                        adv_li.text as ""adv_li.text"",
                        adv_li.additional_text as ""adv_li.additional_text"",
                        adv_li.icon_url as ""adv_li.icon_url"",
                        adv_li.advantages_id as ""adv_li.advantages_id""
                 from advantages_list as adv_li
                where (text=@text)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {

                    myCommand.Parameters.AddWithValue("@text", text);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult(table);
        }

        ////------------------------------------------- POST by name advantagesList ------------------------------------------------
        [HttpPost]
        public JsonResult PostServices(DB7_AdvantagesListDTO advantagesList)
        {
            int id = 0;
            string query = @"
                insert into advantages_list
                (id,text,additional_text,icon_url,advantages_id)
                values 
                (@id,@text,@additional_text,@icon_url,@advantages_id)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", advantagesList.id);
                    myCommand.Parameters.AddWithValue("@text", advantagesList.text);
                    myCommand.Parameters.AddWithValue("@additional_text", advantagesList.additional_text);
                    myCommand.Parameters.AddWithValue("@icon_url", advantagesList.icon_url);
                    myCommand.Parameters.AddWithValue("@advantages_id", advantagesList.advantages_id);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("New advantages_list Added Successfully");
        }


        ////------------------------------------------- PUT (update) IN advantagesList ------------------------------------------------

        [HttpPut]
        public JsonResult PutInServices(DB7_AdvantagesListDTO advantagesList)
        {
            string query = @"
                update advantages_list
                    set id = @id,
                    text = @text,
                    additional_text = @additional_text,
                    icon_url = @icon_url,
                    advantages_id = @advantages_id
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
                    myCommand.Parameters.AddWithValue("@id", advantagesList.id);
                    myCommand.Parameters.AddWithValue("@text", advantagesList.text);
                    myCommand.Parameters.AddWithValue("@additional_text", advantagesList.additional_text);
                    myCommand.Parameters.AddWithValue("@icon_url", advantagesList.icon_url);
                    myCommand.Parameters.AddWithValue("@advantages_id", advantagesList.advantages_id);
                    //myCommand.Parameters.AddWithValue("@services_list_id", services.services_list_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("advantages_list Updated Successfully");
        }


        ////---------------------------------------------- Delete advantages_list by Id ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult DeleteServices(int id)
        {
            string query = @"
                delete from advantages_list
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
            return new JsonResult("advantages_list Deleted Successfully");
        }
    }
}
