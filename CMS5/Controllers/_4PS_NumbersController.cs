using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers.SectionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class _4PS_NumbersController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public _4PS_NumbersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }




        //------------------------------------------- GET by name numbers ------------------------------------------------
        //-------------------Get all numbers -------------------
        [HttpGet]
        public JsonResult Get_numbers()
        {
            //string name = "numbers";

            string query = @"
                select 
                        n.id as ""id"",
                        n.section_name as ""section_name"",
                        n.section_type as ""section_type"",
                        n.layout_position as ""layout_position"",
                        n.last_mod_date as ""last_mod_date"",
                        n.user_name as ""user_name"",
                        n.text as ""text"",
                        n.value1 as ""value1"",
                        n.description1 as ""description1"",
                        n.value2 as ""value2"",
                        n.description2 as ""description2""
                from numbers as n
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


        //------------------- Get numbers by section_name -------------------

        [HttpGet("{section_name}")]
        public JsonResult GetNumbersByTitle(string section_name)
        {
            //string name = "numbers";
            string query = @"
                select 
                        n.id as ""id"",
                        n.section_name as ""section_name"",
                        n.section_type as ""section_type"",
                        n.layout_position as ""layout_position"",
                        n.last_mod_date as ""last_mod_date"",
                        n.user_name as ""user_name"",
                        n.text as ""text"",
                        n.value1 as ""value1"",
                        n.description1 as ""description1"",
                        n.value2 as ""value2"",
                        n.description2 as ""description2""
                 from numbers as n 
                 where n.section_name=@section_name
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

        ////------------------------------------------- POST by name numbers ------------------------------------------------
        [HttpPost]
        public JsonResult PostNumbers(DB4_NumbersDTO numbers)
        {
            int id = 0;
            string query = @"
                insert into numbers
                (id,section_name,section_type,layout_position,last_mod_date,user_name,text,value1,description1,value2,description2)
                values 
                (@id,@section_name,@section_type,@layout_position,@last_mod_date,@user_name,@text,@value1,@description1,@value2,@description2)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", numbers.id);
                    myCommand.Parameters.AddWithValue("@section_name", numbers.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", numbers.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", numbers.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", numbers.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", numbers.user_name);
                    myCommand.Parameters.AddWithValue("@text", numbers.text);
                    myCommand.Parameters.AddWithValue("@value1", numbers.value1);
                    myCommand.Parameters.AddWithValue("@description1", numbers.description1);
                    myCommand.Parameters.AddWithValue("@value2", numbers.value2);
                    myCommand.Parameters.AddWithValue("@description2", numbers.description2);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("New numbers Added Successfully");
        }


        ////------------------------------------------- PUT (update) IN numbers ------------------------------------------------

        [HttpPut]
        public JsonResult PutInNumbers(DB4_NumbersDTO numbers)
        {
            string query = @"
                update numbers
                set id = @id,
                section_name = @section_name,
                section_type = @section_type,
                layout_position = @layout_position,
                last_mod_date = @last_mod_date,
                user_name = @user_name,
                text = @text,
                value1 = @value1,
                description1 = @description1,
                value2 = @value2,
                description2 = @description2
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
                    myCommand.Parameters.AddWithValue("@id", numbers.id);
                    myCommand.Parameters.AddWithValue("@section_name", numbers.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", numbers.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", numbers.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", numbers.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", numbers.user_name);
                    myCommand.Parameters.AddWithValue("@text", numbers.text);
                    myCommand.Parameters.AddWithValue("@value1", numbers.value1);
                    myCommand.Parameters.AddWithValue("@description1", numbers.description1);
                    myCommand.Parameters.AddWithValue("@value2", numbers.value2);
                    myCommand.Parameters.AddWithValue("@description2", numbers.description2);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("numbers Updated Successfully");
        }


        ////---------------------------------------------- Delete by Id and name(Baner) ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult DeleteNumbers(int id)
        {
            string query = @"
                delete from numbers
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
            return new JsonResult("Numbers Deleted Successfully");
        }


    }
}



