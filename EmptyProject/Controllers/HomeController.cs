using EmptyProject.Models;
using EmptyProject.Repository;
using EmptyProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmptyProject.Controllers
{
    public class HomeController:Controller
    {
        private readonly IStudentRepository db;
        public HomeController(IStudentRepository studentRepository)
        {
            db = studentRepository;
        }
        public ActionResult Index()
        {
            var students=db.GetEntitysList();
            IList<StudentViewModel> studentsViewModel = new List<StudentViewModel>();
            foreach (var s in students)
            {
                var studentViewModel = StudentViewModelInit(s);
                studentsViewModel.Add(studentViewModel);
            }
            return View(studentsViewModel);
        }

        StudentViewModel StudentViewModelInit(Student student)
        {
            var studentViewModel = new StudentViewModel() 
            {
                Id=student.Id,
                Age=student.Age,
                Name=student.Name
            };
            return studentViewModel;
        }
        Student StudentInit(StudentViewModel studentViewModel)
        {
            var student = new Student()
            {
                Id = studentViewModel.Id,
                Age = studentViewModel.Age,
                Name = studentViewModel.Name
            };
            return student;
        }

        public ActionResult Details(int id)
        {
            Student student = db.GetEntity(id);
            StudentViewModel studentViewModel = StudentViewModelInit(student);
            return View(studentViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var student = StudentInit(studentViewModel);
                db.Create(student);
                return RedirectToAction("Index");
            }

            return View(studentViewModel);
        }

        public ActionResult Edit(int id)
        {
            Student student = db.GetEntity(id);
            var studentViewModel = StudentViewModelInit(student);
            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                var student = StudentInit(studentViewModel);
                db.Edit(student);
                return RedirectToAction("Index");
            }
            return View(studentViewModel);
        }

        public ActionResult Delete(int id)
        {
            Student student = db.GetEntity(id);
            var studentViewModel = StudentViewModelInit(student);
            return View(studentViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.GetEntity(id);
            db.Delete(student);
            return RedirectToAction("Index");
        }
    }
}
