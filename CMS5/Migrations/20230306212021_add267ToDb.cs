using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CMS5.Migrations
{
    /// <inheritdoc />
    public partial class add267ToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "advantages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    section_name = table.Column<string>(type: "text", nullable: false),
                    section_type = table.Column<string>(type: "text", nullable: false),
                    layout_position = table.Column<int>(type: "integer", nullable: false),
                    last_mod_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advantages", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    section_name = table.Column<string>(type: "text", nullable: false),
                    section_type = table.Column<string>(type: "text", nullable: false),
                    layout_position = table.Column<int>(type: "integer", nullable: false),
                    last_mod_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "testimonials",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    section_name = table.Column<string>(type: "text", nullable: false),
                    section_type = table.Column<string>(type: "text", nullable: false),
                    layout_position = table.Column<int>(type: "integer", nullable: false),
                    last_mod_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    additional_text = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonials", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "advantages_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    additional_text = table.Column<string>(type: "text", nullable: false),
                    icon_url = table.Column<string>(type: "text", nullable: false),
                    advantages_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_advantages_list", x => x.id);
                    table.ForeignKey(
                        name: "FK_advantages_list_advantages_advantages_id",
                        column: x => x.advantages_id,
                        principalTable: "advantages",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    text = table.Column<string>(type: "text", nullable: false),
                    additional_text = table.Column<string>(type: "text", nullable: false),
                    baner_section_name = table.Column<string>(type: "text", nullable: false),
                    services_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services_list", x => x.id);
                    table.ForeignKey(
                        name: "FK_services_list_services_services_id",
                        column: x => x.services_id,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "testimonials_list",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    opinion = table.Column<string>(type: "text", nullable: false),
                    author = table.Column<string>(type: "text", nullable: false),
                    author_description = table.Column<string>(type: "text", nullable: false),
                    testimonials_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_testimonials_list", x => x.id);
                    table.ForeignKey(
                        name: "FK_testimonials_list_testimonials_testimonials_id",
                        column: x => x.testimonials_id,
                        principalTable: "testimonials",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_advantages_list_advantages_id",
                table: "advantages_list",
                column: "advantages_id");

            migrationBuilder.CreateIndex(
                name: "IX_services_list_services_id",
                table: "services_list",
                column: "services_id");

            migrationBuilder.CreateIndex(
                name: "IX_testimonials_list_testimonials_id",
                table: "testimonials_list",
                column: "testimonials_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "advantages_list");

            migrationBuilder.DropTable(
                name: "services_list");

            migrationBuilder.DropTable(
                name: "testimonials_list");

            migrationBuilder.DropTable(
                name: "advantages");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "testimonials");
        }
    }
}
