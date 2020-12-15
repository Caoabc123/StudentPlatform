using Microsoft.EntityFrameworkCore;
using StudentPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPlatform.Data
{
    public class StudentPlatformContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public StudentPlatformContext(DbContextOptions<StudentPlatformContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            // skapa composite primary key
            // studentId och courseId är tillsammans alltså primary key
            modelbuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            // säga till EF vad relationen mellan studentcourse och student är
            // sätta att studentId är foreign key 
            modelbuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);
                //.OnDelete(DeleteBehavior.Restrict)
                

            // säga till EF vad relationen mellan studentcourse och course är
            // sätta att courseId är foreign key 
            modelbuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
                //.OnDelete(DeleteBehavior.Restrict)
        }
    }
}
