using DemoProject.Models;
using DemoProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        //private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly List<Student> students = new List<Student>
        {
            new Student { Id = 1, FirstName = "Ajit", LastName = "Verma", Age = 24, Gender = Gender.Male, Address = "Kurla", Class = "BScIT" },
            new Student { Id = 2, FirstName = "Rajesh", LastName = "Sharma", Age = 22, Gender = Gender.Male, Address = "Ghatkopar", Class = "BScIT" }
        };
        private readonly IStudent _student;
        public StudentController()
        {
            _student = new StudentRepository(students);
        }

        // GET: Student
        public ActionResult Index(string sortField)
        {
            string successMessage = TempData["SuccessMessage"] as string;
            ViewBag.SuccessMessage = successMessage;
            ViewBag.SortFirstName = sortField == "FirstName" ? "FirstNameDesc" : "FirstName";
            ViewBag.SortLastName = sortField == "LastName" ? "LastNameDesc" : "LastName";
            ViewBag.SortAgeName = sortField == "Age" ? "AgeDesc" : "Age";
            ViewBag.SortClassName = sortField == "Class" ? "ClassDesc" : "Class";
            IEnumerable<Student> students = _student.GetStudents();
            switch (sortField)
            {
                case "FirstName":
                    students = students.OrderBy(s => s.FirstName);
                    break;
                case "FirstNameDesc":
                    students = students.OrderByDescending(s => s.FirstName);
                    break;
                case "LastName":
                    students = students.OrderBy(s => s.LastName);
                    break;
                case "LastNameDesc":
                    students = students.OrderByDescending(s => s.LastName);
                    break;
                case "Age":
                    students = students.OrderBy(s => s.Age);
                    break;
                case "AgeDesc":
                    students = students.OrderByDescending(s => s.Age);
                    break;
                case "Class":
                    students = students.OrderBy(s => s.Class);
                    break;
                case "ClassDesc":
                    students = students.OrderByDescending(s => s.Class);
                    break;
                // Add cases for other columns as needed
                default:
                    students = students.OrderBy(s => s.Id);
                    break;
            }
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student = _student.GetStudentById(id);
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = _student.SaveStudent(student);
                    if (result)
                    {
                        TempData["SuccessMessage"] = "Record saved successfully.";
                        return RedirectToAction("Index");
                    }
                }
                return View(student);
            }
            catch (Exception ex)
            {
                //logger.Error($"Error {ex.Message} \n {ex.StackTrace}");
                return View(student);
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = _student.GetStudentById(id);
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(Student student)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool result = _student.UpdateStudent(student);
                    if (result)
                    {
                        TempData["SuccessMessage"] = "Record updated successfully.";
                        return RedirectToAction("Index");
                    }
                }
                return View(student);
            }
            catch (Exception ex)
            {
                //logger.Error($"Error {ex.Message} \n {ex.StackTrace}");
                return View(student);
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            Student student = _student.GetStudentById(id);
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                bool result = _student.DeleteStudentById(id);
                if (result)
                {
                    TempData["SuccessMessage"] = "Record deleted successfully.";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["ErrorMessage"] = "Error deleting user.";
                    return RedirectToAction("Delete", new { id });
                }
            }
            catch (Exception ex)
            {
                // logger.Error($"Error {ex.Message} \n {ex.StackTrace}");
                return View();
            }
        }
    }
}
