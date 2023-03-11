using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Data;
using System.Xml.Linq;
using WebApplication1.Models.DTO;

namespace WebApplication1.Controllers.SectionsController
{
    [Route("api/[controller]")]
    [ApiController]
    public class _1PS_HeroBanerController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public _1PS_HeroBanerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //------------------------------------------- GET by name hero_banners ------------------------------------------------
        //-------------------Get all hero_banners -------------------
        [HttpGet]
        public JsonResult Get_Hero_Banners()
        {
            //string name = "hero_banners";

            string query = @"
                select 
                        hb.id as ""id"",
                        hb.section_name as ""section_name"",
                        hb.section_type as ""section_type"",
                        hb.layout_position as ""layout_position"",
                        hb.last_mod_date as ""last_mod_date"",
                        hb.user_name as ""user_name"",
                        hb.text as ""text"",
                        hb.additional_text as ""additional_text"",
                        hb.background_image as ""background_image"" 
                from hero_banners as hb
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


        //------------------- Get hero_banners by section_name -------------------

        [HttpGet("{section_name}")]
        public JsonResult GetHero_BannersByTitle(string section_name)
        {
            //string name = "hero_banners";
            string query = @"
                select 
                        hb.id as ""id"",
                        hb.section_name as ""section_name"",
                        hb.section_type as ""section_type"",
                        hb.layout_position as ""layout_position"",
                        hb.last_mod_date as ""last_mod_date"",
                        hb.user_name as ""user_name"",
                        hb.text as ""text"",
                        hb.additional_text as ""additional_text"",
                        hb.background_image as ""background_image""
                   from hero_banners as hb 
                where hb.section_name=@section_name
                 
                
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

        ////------------------------------------------- POST by name hero_banners ------------------------------------------------
        [HttpPost]
        public JsonResult hero_banners(DB1_HeroBannerDTO hero_banners)
        {
            int id = 0;
            string query = @"
                insert into hero_banners
                (id,section_name,section_type,layout_position,last_mod_date,user_name,text,additional_text,background_image)
                values 
                (@id,@section_name,@section_type,@layout_position,@last_mod_date,@user_name,@text,@additional_text,@background_image)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("SampleDBConnection");
            NpgsqlDataReader myReader;
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", hero_banners.id);
                    myCommand.Parameters.AddWithValue("@section_name", hero_banners.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", hero_banners.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", hero_banners.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", hero_banners.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", hero_banners.user_name);
                    myCommand.Parameters.AddWithValue("@text", hero_banners.text);
                    myCommand.Parameters.AddWithValue("@additional_text", hero_banners.additional_text);
                    myCommand.Parameters.AddWithValue("@background_image", hero_banners.background_image);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("New hero_banners Added Successfully");
        }


        ////------------------------------------------- PUT (update) IN hero_banners ------------------------------------------------

        [HttpPut]
        public JsonResult PutInHero_Banners(DB1_HeroBannerDTO hero_banners)
        {
            string query = @"
                update hero_banners
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
                    myCommand.Parameters.AddWithValue("@id", hero_banners.id);
                    myCommand.Parameters.AddWithValue("@section_name", hero_banners.section_name);
                    myCommand.Parameters.AddWithValue("@section_type", hero_banners.section_type);
                    myCommand.Parameters.AddWithValue("@layout_position", hero_banners.layout_position);
                    myCommand.Parameters.AddWithValue("@last_mod_date", hero_banners.last_mod_date);
                    myCommand.Parameters.AddWithValue("@user_name", hero_banners.user_name);
                    myCommand.Parameters.AddWithValue("@text", hero_banners.text);
                    myCommand.Parameters.AddWithValue("@additional_text", hero_banners.additional_text);
                    myCommand.Parameters.AddWithValue("@background_image", hero_banners.background_image);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();

                }
            }

            return new JsonResult("Hero_banners Updated Successfully");
        }


        ////---------------------------------------------- Delete by Id and name(Baner) ----------------------------------------------
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from hero_banners
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
            return new JsonResult("Hero_banners Deleted Successfully");
        }
    }
}
