using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniversity.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "tblStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "tblStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "tblCourse",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            //migrationBuilder.AddColumn<int>(
            //    name: "DepartmentID",
            //    table: "tblCourse",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblInstructor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblInstructor", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblCourseAssignment",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    CourseID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCourseAssignment", x => new { x.CourseID, x.InstructorID });
                    table.ForeignKey(
                        name: "FK_tblCourseAssignment_tblCourse_CourseID",
                        column: x => x.CourseID,
                        principalTable: "tblCourse",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblCourseAssignment_tblInstructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "tblInstructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDepartment",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartment", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_tblDepartment_tblInstructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "tblInstructor",
                        principalColumn: "ID");
                });

                migrationBuilder.Sql("INSERT INTO dbo.tblDepartment (Name, Budget, StartDate) VALUES ('Temp', 0.00, GETDATE())");
                // Default value for FK points to department created above, with
                // defaultValue changed to 1 in following AddColumn statement.

                migrationBuilder.AddColumn<int>(
                    name: "DepartmentID",
                    table: "tblCourse",
                    nullable: false,
                    defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "tblOfficeAssignment",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOfficeAssignment", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_tblOfficeAssignment_tblInstructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "tblInstructor",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCourse_DepartmentID",
                table: "tblCourse",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCourseAssignment_InstructorID",
                table: "tblCourseAssignment",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDepartment_InstructorID",
                table: "tblDepartment",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCourse_tblDepartment_DepartmentID",
                table: "tblCourse",
                column: "DepartmentID",
                principalTable: "tblDepartment",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCourse_tblDepartment_DepartmentID",
                table: "tblCourse");

            migrationBuilder.DropTable(
                name: "tblCourseAssignment");

            migrationBuilder.DropTable(
                name: "tblDepartment");

            migrationBuilder.DropTable(
                name: "tblOfficeAssignment");

            migrationBuilder.DropTable(
                name: "tblInstructor");

            migrationBuilder.DropIndex(
                name: "IX_tblCourse_DepartmentID",
                table: "tblCourse");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "tblCourse");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "tblStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "tblStudent",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "tblCourse",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
