using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityStudentsApp.Data;
using UniversityStudentsApp.Models;
using UniversityStudentsApp.ViewModels;

namespace UniversityStudentsApp.Controllers
{
    public class TeachersController : Controller
    {
        private readonly UniversityStudentsAppContext _context;

        public TeachersController(UniversityStudentsAppContext context)
        {
            _context = context;
        }

        // GET: Teachers
        public async Task<IActionResult> Index(string teacherName, string teacherDegree, string teacherAcRank)
        {
            IQueryable<Teacher> professors = _context.Teacher.AsQueryable();

            IQueryable<String> teacherDegreeQuery = _context.Teacher
                .OrderBy(m => m.Degree).Select(m => m.Degree).Distinct();

            IQueryable<String> teacherAcRankQuery = _context.Teacher
                .OrderBy(m => m.AcademicRank).Select(m => m.AcademicRank).Distinct();

            if (!String.IsNullOrEmpty(teacherName))
            {
                professors = professors.Where(s => s.FirstName.Contains(teacherName) || s.LastName.Contains(teacherName));
            }

            if (!String.IsNullOrEmpty(teacherDegree))
            {
                professors = professors.Where(x => x.Degree == teacherDegree);
            }
            if (!String.IsNullOrEmpty(teacherAcRank))
            {
                professors = professors.Where(x => x.AcademicRank == teacherAcRank);
            }

            professors = professors.Include(m => m.FirstTeacherCourses)
                                    .Include(m => m.SecondTeacherCourses);


            var teacherFilterViewModel = new TeacherFilterViewModel
            {
                Professors = await professors.ToListAsync(),
                Degrees = new SelectList(await teacherDegreeQuery.ToListAsync()),
                AcademicRanks = new SelectList(await teacherAcRankQuery.ToListAsync())

            };

            return View(teacherFilterViewModel);
        }

        // GET: Teachers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .Include(p => p.FirstTeacherCourses)
                .Include(p => p.SecondTeacherCourses)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // GET: Teachers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Degree,AcademicRank,OfficeNumber,HireDate")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher.FindAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Degree,AcademicRank,OfficeNumber,HireDate")] Teacher teacher)
        {
            if (id != teacher.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacher);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherExists(teacher.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacher = await _context.Teacher
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacher = await _context.Teacher.FindAsync(id);
            _context.Teacher.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherExists(int id)
        {
            return _context.Teacher.Any(e => e.Id == id);
        }
    }
}
