﻿using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using WebApplication1.Models.DTO;

namespace CMS_Projekt_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class _6PS_TestimonialsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public _6PS_TestimonialsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET ------------------------------------------------
        //-------------------Get all testimonials -------------------
        [HttpGet]
        public JsonResult Get_All_Testimonials()
        {


            string query = @"
                select 
                        tm.id as ""tm.id"",
                        tm.section_name as ""tm.section_name"",
                        tm.section_type as ""tm.section_type"",
                        tm.layout_position as ""tm.layout_position"",
                        tm.last_mod_date as ""tm.last_mod_date"",
                        tm.user_name as ""tm.user_name"",  
                        tm.text as ""tm.text"",
                        tm.additional_text as ""tm.additional_text""
                        tm.services_list_id as ""tm.services_list_id""
                 from testimonials as tm
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
        public JsonResult GetTestimonialsByTitle(string section_name)
        {

            string query = @"
                select 
                        tm.id as ""tm.id"",
                        tm.section_name as ""tm.section_name"",
                        serv.section_type as ""serv.section_type"",
                        serv.layout_position as ""serv.layout_position"",
                        serv.last_mod_date as ""serv.last_mod_date"",
                        serv.user_name as ""serv.user_name"",  
                        serv.text as ""serv.text"",
                        serv.additional_text as ""serv.additional_text""
                        serv.services_list_id as ""serv.services_list_id""
                 from testimonials as tm
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
        public JsonResult PostTestimonials(DB6_TestimonialsDTO testimonials)
        {
            int id = 0;
            string query = @"
                insert into testimonials
                (id,section_name,section_type,layout_position,last_mod_date,user_name,text,additional_text,services_list_id)
                values 
                (@id,@section_name,@section_type,@layout_position,@last_mod_date,@user_name,@text,@additional_text,@services_list_id)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", testimonials.id);
                    myCommand.Parameters.AddWithValue("@section_name", testimonials.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", testimonials.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", testimonials.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", testimonials.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", testimonials.user_name);
                    myCommand.Parameters.AddWithValue("@text", testimonials.text);
                    myCommand.Parameters.AddWithValue("@additional_text", testimonials.additional_text);
                    myCommand.Parameters.AddWithValue("@services_list_id", testimonials.testimonials_list_id);


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
        public JsonResult PutInTestimonials(DB6_TestimonialsDTO testimonials)
        {
            string query = @"
                update testimonials
                set id = @id,
                section_name = @section_name,
                section_type = @section_type,
                layout_position = @layout_position,
                last_mod_date = @last_mod_date,
                user_name = @user_name
                text = @text,
                additional_text = @additional_text,
                services_list = @services_list
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
                    myCommand.Parameters.AddWithValue("@id", testimonials.id);
                    myCommand.Parameters.AddWithValue("@section_name", testimonials.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", testimonials.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", testimonials.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", testimonials.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", testimonials.user_name);
                    myCommand.Parameters.AddWithValue("@text", testimonials.text);
                    myCommand.Parameters.AddWithValue("@additional_text", testimonials.additional_text);
                    myCommand.Parameters.AddWithValue("@testimonials_list_id", testimonials.testimonials_list_id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("testimonials Updated Successfully");
        }


        ////---------------------------------------------- Delete Services by Id ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult DeleteTestimonials(int id)
        {
            string query = @"
                delete from testimonials
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
            return new JsonResult("testimonials Deleted Successfully");
        }

    }
}
