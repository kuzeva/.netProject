using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityStudentsApp.Models;

namespace UniversityStudentsApp.Data
{
    public class UniversityStudentsAppContext : DbContext
    {
        public UniversityStudentsAppContext (DbContextOptions<UniversityStudentsAppContext> options)
                : base(options) { }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Course> Courses { get; set; }
        
        public DbSet<Student> Student { get; set; }

        public DbSet<Enrollment> Enrollment { get; set; }

        protected override void OnModelCreating (ModelBuilder builder)
        {
            builder.Entity<Enrollment>()
                .HasOne<Student>(p => p.Student)
                .WithMany(p => p.Courses)
                .HasForeignKey(p => p.CourseId);

        builder.Entity<Enrollment>()
                .HasOne<Course>(p => p.Course)
                .WithMany(p => p.Students)
                .HasForeignKey(p => p.StudentId);

        builder.Entity<Course>()
                .HasOne<Teacher>(p => p.FirstTeacher)
                .WithMany(p => p.FirstTeacherCourses)
                .HasForeignKey(p => p.FirstTeacherId);

        builder.Entity<Course>()
                .HasOne<Teacher>(p => p.SecondTeacher)
                .WithMany(p => p.SecondTeacherCourses)
                .HasForeignKey(p => p.SecondTeacherId);
            
      

    }

    }
}
