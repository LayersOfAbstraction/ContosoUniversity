using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniversity.Migrations
{
    public partial class TableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "tblStudent");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "tblEnrollment");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "tblCourse");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentID",
                table: "tblEnrollment",
                newName: "IX_tblEnrollment_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseID",
                table: "tblEnrollment",
                newName: "IX_tblEnrollment_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblStudent",
                table: "tblStudent",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblEnrollment",
                table: "tblEnrollment",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblCourse",
                table: "tblCourse",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEnrollment_tblCourse_CourseID",
                table: "tblEnrollment",
                column: "CourseID",
                principalTable: "tblCourse",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblEnrollment_tblStudent_StudentID",
                table: "tblEnrollment",
                column: "StudentID",
                principalTable: "tblStudent",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEnrollment_tblCourse_CourseID",
                table: "tblEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_tblEnrollment_tblStudent_StudentID",
                table: "tblEnrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblStudent",
                table: "tblStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblEnrollment",
                table: "tblEnrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblCourse",
                table: "tblCourse");

            migrationBuilder.RenameTable(
                name: "tblStudent",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "tblEnrollment",
                newName: "Enrollments");

            migrationBuilder.RenameTable(
                name: "tblCourse",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_tblEnrollment_StudentID",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_tblEnrollment_CourseID",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "EnrollmentID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Courses_CourseID",
                table: "Enrollments",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Students_StudentID",
                table: "Enrollments",
                column: "StudentID",
                principalTable: "Students",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
