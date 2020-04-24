using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniversityStudentsApp.Models;

namespace UniversityStudentsApp.ViewModels
{
    public class TeacherFilterViewModel
    {
        public IList<Teacher> Professors { get; set; }
        public string NameSearch { get; set; }

        public SelectList Degrees { get; set; }
        public string ProfessorDegree { get; set; }
        public SelectList AcademicRanks { get; set; }
        public string ProfessorAcademicRank { get; set; }
    }
}
