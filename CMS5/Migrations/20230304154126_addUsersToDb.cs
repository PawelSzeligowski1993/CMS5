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
                name: "advantages_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    additional_text = table.Column<string>(type: "text", nullable: false),
                    icon_url = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advantages_list", x => x.id);
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
                name: "services_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    text = table.Column<string>(type: "text", nullable: false),
                    additional_text = table.Column<string>(type: "text", nullable: false),
                    Baner_section_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services_list", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "testimonials_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    opinion = table.Column<string>(type: "text", nullable: false),
                    author = table.Column<string>(type: "text", nullable: false),
                    author_description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonials_list", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "advantages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    section_name = table.Column<string>(type: "text", nullable: false),
                    section_type = table.Column<string>(type: "text", nullable: false),
                    layout_position = table.Column<int>(type: "integer", nullable: false),
                    last_mod_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    advantages_list_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advantages", x => x.id);
                    table.ForeignKey(
                        name: "FK_advantages_advantages_list_advantages_list_id",
                        column: x => x.advantages_list_id,
                        principalTable: "advantages_list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    section_name = table.Column<string>(type: "text", nullable: false),
                    section_type = table.Column<string>(type: "text", nullable: false),
                    layout_position = table.Column<int>(type: "integer", nullable: false),
                    last_mod_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    services_list_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.id);
                    table.ForeignKey(
                        name: "FK_services_services_list_services_list_id",
                        column: x => x.services_list_id,
                        principalTable: "services_list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "testimonials",
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
                    testimonials_list_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonials", x => x.id);
                    table.ForeignKey(
                        name: "FK_testimonials_testimonials_list_testimonials_list_id",
                        column: x => x.testimonials_list_id,
                        principalTable: "testimonials_list",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_advantages_advantages_list_id",
                table: "advantages",
                column: "advantages_list_id");

            migrationBuilder.CreateIndex(
                name: "IX_services_services_list_id",
                table: "services",
                column: "services_list_id");

            migrationBuilder.CreateIndex(
                name: "IX_testimonials_testimonials_list_id",
                table: "testimonials",
                column: "testimonials_list_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "about_us");

            migrationBuilder.DropTable(
                name: "advantages");

            migrationBuilder.DropTable(
                name: "hero_banners");

            migrationBuilder.DropTable(
                name: "numbers");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "testimonials");

            migrationBuilder.DropTable(
                name: "work_with_us");

            migrationBuilder.DropTable(
                name: "advantages_list");

            migrationBuilder.DropTable(
                name: "services_list");

            migrationBuilder.DropTable(
                name: "testimonials_list");
        }
    }
}
