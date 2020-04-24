using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityStudentsApp.Data;

namespace UniversityStudentsApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniversityStudentsAppContext(
                serviceProvider.GetRequiredService<DbContextOptions<UniversityStudentsAppContext>>()))
            {
                if(context.Student.Any() || context.Teacher.Any() || context.Courses.Any() || context.Enrollment.Any())
                {
                    return;
                }

                context.Student.AddRange(
                    new Student { StudentId = "94/2019", FirstName = "Petre", LastName = "Petrevski", AcquiredCredits = 30, EducationLevel = "First Year", EnrollmentDate = DateTime.Parse("2019 - 8 - 21"), CurrentSemester = 2 },
                    new Student { StudentId = "64/2019", FirstName = "Zlatko", LastName = "Zlatkovski", AcquiredCredits = 25, EducationLevel = "First Year", EnrollmentDate = DateTime.Parse("2019 - 8 - 21"), CurrentSemester = 2 },
                    new Student { StudentId = "59/2019", FirstName = "Ivan", LastName = "Ivanovski", AcquiredCredits = 30, EducationLevel = "First Year", EnrollmentDate = DateTime.Parse("2019 - 8 - 21"), CurrentSemester = 2 },
                    new Student { StudentId = "26/2019", FirstName = "Stefan", LastName = "Stefanovski", AcquiredCredits = 30, EducationLevel = "First Year", EnrollmentDate = DateTime.Parse("2019 - 8 - 21"), CurrentSemester = 2 }
                    );
                context.SaveChanges();

                context.Teacher.AddRange(
                    new Teacher { FirstName = "Marija", LastName = "Milanovska", AcademicRank = "redoven profesor", Degree = "Doktor na nauki", HireDate = DateTime.Parse("2000-2-11"), OfficeNumber = "256"},
                    new Teacher { FirstName = "Nikola", LastName = "Nikolovski", AcademicRank = "asistent", Degree = "Magistar", HireDate = DateTime.Parse("2016-5-20"), OfficeNumber = "315" },
                    new Teacher { FirstName = "Stojce", LastName = "Stojkovski", AcademicRank = "redoven profesor", Degree = "Doktor na nauki", HireDate = DateTime.Parse("1998-6-1"), OfficeNumber = "249" },
                    new Teacher { FirstName = "Stefanija", LastName = "Stefanovska", AcademicRank = "asistent", Degree = "Magistar", HireDate = DateTime.Parse("2017-9-5"), OfficeNumber = "351" }
                    );
                context.SaveChanges();

                context.Courses.AddRange(
                    new Course
                    {
                        Title = "Matenatika",
                        Credits = 6,
                        Programme = "Programme",
                        EducationLevel = "Dificult",
                        Semester = 1,
                        FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Marija" && d.LastName == "Milanovska").Id,
                        SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Nikola" && d.LastName == "Nikolovski").Id
                    },
                    new Course
                    {
                        Title = "Fizika",
                        Credits = 6,
                        Programme = "Programme",
                        EducationLevel = "Dificult",
                        Semester = 1,
                        FirstTeacherId = context.Teacher.Single(d => d.FirstName == "Stojce" && d.LastName == "Stojkovski").Id,
                        SecondTeacherId = context.Teacher.Single(d => d.FirstName == "Stefanija" && d.LastName == "Steefanovska").Id
                    }
                    ) ;
                context.SaveChanges();

                context.Enrollment.AddRange(
                    new Enrollment { CourseId = 1 , StudentId = 1 , ExamPoints = 62 , AditionalPoints = 10, SeminarPoints = 10 , ProjectPoints = 20, Year = 2020, Grade = 8, FinishDate=DateTime.Parse("2020-1-15")},
                    new Enrollment { CourseId = 1, StudentId = 2, ExamPoints = 49, AditionalPoints = 10, SeminarPoints = 10, ProjectPoints = 20, Year = 2020, Grade = 7, FinishDate = DateTime.Parse("2020-1-15") },
                    new Enrollment { CourseId = 1, StudentId = 3, ExamPoints = 73, AditionalPoints = 10, SeminarPoints = 10, ProjectPoints = 20, Year = 2020, Grade = 9, FinishDate = DateTime.Parse("2020-1-15") },
                    new Enrollment { CourseId = 1, StudentId = 4, ExamPoints = 66, AditionalPoints = 9, SeminarPoints = 10, ProjectPoints = 20, Year = 2020, Grade = 8, FinishDate = DateTime.Parse("2020-1-15") },
                    new Enrollment { CourseId = 2, StudentId = 1, ExamPoints = 56, AditionalPoints = 10, SeminarPoints = 10, ProjectPoints = 20, Year = 2020, Grade = 7, FinishDate = DateTime.Parse("2020-1-15") },
                    new Enrollment { CourseId = 2, StudentId = 3, ExamPoints = 49, AditionalPoints = 8, SeminarPoints = 10, ProjectPoints = 20, Year = 2020, Grade = 6, FinishDate = DateTime.Parse("2020-1-15") },
                    new Enrollment { CourseId = 2, StudentId = 4, ExamPoints = 84, AditionalPoints = 10, SeminarPoints = 10, ProjectPoints = 20, Year = 2020, Grade = 10, FinishDate = DateTime.Parse("2020-1-15") }

                    );
                context.SaveChanges();
           
            }
        }

    }
}
