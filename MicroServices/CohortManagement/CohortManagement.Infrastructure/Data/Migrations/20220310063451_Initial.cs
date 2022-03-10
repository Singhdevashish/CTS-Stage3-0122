using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CohortManagement.Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cohorts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CohortCode = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    TechnologyStack = table.Column<string>(unicode: false, maxLength: 10, nullable: true),
                    Coach = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    CreateOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cohorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    DateOfJoining = table.Column<DateTime>(type: "date", nullable: false),
                    CohortId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainees_Cohorts_CohortId",
                        column: x => x.CohortId,
                        principalTable: "Cohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trainees_CohortId",
                table: "Trainees",
                column: "CohortId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trainees");

            migrationBuilder.DropTable(
                name: "Cohorts");
        }
    }
}
