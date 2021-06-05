    using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalWard_Manjot.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorName = table.Column<string>(nullable: false),
                    Specialty = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nurses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseName = table.Column<string>(nullable: false),
                    Specialty = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nurses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: false),
                    NurseID = table.Column<int>(nullable: false),
                    DoctorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Wards_Doctors_DoctorID",
                        column: x => x.DoctorID,
                        principalTable: "Doctors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wards_Nurses_NurseID",
                        column: x => x.NurseID,
                        principalTable: "Nurses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patiens",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    WardID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patiens", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Patiens_Wards_WardID",
                        column: x => x.WardID,
                        principalTable: "Wards",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patiens_WardID",
                table: "Patiens",
                column: "WardID");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_DoctorID",
                table: "Wards",
                column: "DoctorID");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_NurseID",
                table: "Wards",
                column: "NurseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Patiens");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Nurses");
        }
    }
}
