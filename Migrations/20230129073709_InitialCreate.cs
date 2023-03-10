using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcEmployee.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "QualificationList",
                columns: table => new
                {
                    QualificationListId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationList", x => x.QualificationListId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    GenderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_Gender_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Gender",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    QualificationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Marks = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    QualificationListId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.QualificationId);
                    table.ForeignKey(
                        name: "FK_Qualification_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Qualification_QualificationList_QualificationListId",
                        column: x => x.QualificationListId,
                        principalTable: "QualificationList",
                        principalColumn: "QualificationListId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderId",
                table: "Employee",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_EmployeeId",
                table: "Qualification",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_QualificationListId",
                table: "Qualification",
                column: "QualificationListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "QualificationList");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
