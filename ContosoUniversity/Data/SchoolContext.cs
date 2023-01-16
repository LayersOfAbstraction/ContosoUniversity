using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("tblCourse");
            modelBuilder.Entity<Enrollment>().ToTable("tblEnrollment");
            modelBuilder.Entity<Student>().ToTable("tblStudent");
            modelBuilder.Entity<Department>().ToTable("tblDepartment");
            modelBuilder.Entity<Instructor>().ToTable("tblInstructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("tblOfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("tblCourseAssignment");
            modelBuilder.Entity<Person>().ToTable("tblPerson");

            modelBuilder.Entity<CourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
        }
    }
}