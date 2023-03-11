using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CMS5.Migrations
{
    /// <inheritdoc />
    public partial class addUsersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "about_us",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    section_name = table.Column<string>(type: "text", nullable: false),
                    section_type = table.Column<string>(type: "text", nullable: false),
                    layout_position = table.Column<int>(type: "integer", nullable: false),
                    last_mod_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    additional_text = table.Column<string>(type: "text", nullable: false),
                    image1 = table.Column<string>(type: "text", nullable: false),
                    image2 = table.Column<string>(type: "text", nullable: false),
                    image3 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_about_us", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "hero_banners",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    section_name = table.Column<string>(type: "text", nullable: false),
                    section_type = table.Column<string>(type: "text", nullable: false),
                    layout_position = table.Column<int>(type: "integer", nullable: false),
                    last_mod_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    additional_text = table.Column<string>(type: "text", nullable: false),
                    background_image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hero_banners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "numbers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    section_name = table.Column<string>(type: "text", nullable: false),
                    section_type = table.Column<string>(type: "text", nullable: false),
                    layout_position = table.Column<int>(type: "integer", nullable: false),
                    last_mod_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    value1 = table.Column<string>(type: "text", nullable: false),
                    description1 = table.Column<string>(type: "text", nullable: false),
                    value2 = table.Column<string>(type: "text", nullable: false),
                    description2 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_numbers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "work_with_us",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    section_name = table.Column<string>(type: "text", nullable: false),
                    section_type = table.Column<string>(type: "text", nullable: false),
                    layout_position = table.Column<int>(type: "integer", nullable: false),
                    last_mod_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    additional_text = table.Column<string>(type: "text", nullable: false),
                    background_image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_work_with_us", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "about_us");

            migrationBuilder.DropTable(
                name: "hero_banners");

            migrationBuilder.DropTable(
                name: "numbers");

            migrationBuilder.DropTable(
                name: "work_with_us");
        }
    }
}
