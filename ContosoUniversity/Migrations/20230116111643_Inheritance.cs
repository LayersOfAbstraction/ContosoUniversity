using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoUniversity.Migrations
{
    public partial class Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblEnrollment_tblStudent_StudentID",
                table: "tblEnrollment");

            migrationBuilder.DropIndex(name: "IX_tblEnrollment_StudentID", table: "tblEnrollment");

            migrationBuilder.RenameTable(name: "tblInstructor", newName: "tblPerson");
            migrationBuilder.AddColumn<DateTime>(name: "EnrollmentDate", table: "tblPerson", nullable: true);
            migrationBuilder.AddColumn<string>(name: "Discriminator", table: "tblPerson", nullable: false, maxLength: 128, defaultValue: "tblInstructor");
            migrationBuilder.AlterColumn<DateTime>(name: "HireDate", table: "tblPerson", nullable: true);
            migrationBuilder.AddColumn<int>(name: "OldId", table: "tblPerson", nullable: true);

            // Copy existing Student data into new tblPerson table.
            migrationBuilder.Sql("INSERT INTO dbo.tblPerson (LastName, FirstName, HireDate, EnrollmentDate, Discriminator, OldId) SELECT LastName, FirstName, null AS HireDate, EnrollmentDate, 'tblStudent' AS Discriminator, ID AS OldId FROM dbo.tblStudent");
            // Fix up existing relationships to match new PK's.
            migrationBuilder.Sql("UPDATE dbo.tblEnrollment SET StudentId = (SELECT ID FROM dbo.tblPerson WHERE OldId = tblEnrollment.StudentId AND Discriminator = 'tblStudent')");

            // Remove temporary key
            migrationBuilder.DropColumn(name: "OldID", table: "tblPerson");

            migrationBuilder.DropTable(
                name: "tblStudent");

            migrationBuilder.CreateIndex(
                 name: "IX_tblEnrollment_StudentID",
                 table: "tblEnrollment",
                 column: "StudentID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblEnrollment_tblPerson_StudentID",
                table: "tblEnrollment",
                column: "StudentID",
                principalTable: "tblPerson",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblEnrollment");

            migrationBuilder.RenameColumn(
                name: "EnrollmentDate",
                table: "tblStudent",
                newName: "tblEnrollmentDate");

            migrationBuilder.CreateTable(
                name: "tblEnrollment",
                columns: table => new
                {
                    tblEnrollmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEnrollment", x => x.tblEnrollmentID);
                    table.ForeignKey(
                        name: "FK_tblEnrollment_tblCourse_CourseID",
                        column: x => x.CourseID,
                        principalTable: "tblCourse",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblEnrollment_tblStudent_StudentID",
                        column: x => x.StudentID,
                        principalTable: "tblStudent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblEnrollment_CourseID",
                table: "tblEnrollment",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEnrollment_StudentID",
                table: "tblEnrollment",
                column: "StudentID");
        }
    }
}
