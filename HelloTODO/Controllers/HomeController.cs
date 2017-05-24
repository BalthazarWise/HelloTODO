using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelloTODO.Models;
using System.Data.Entity;
using System.IO;

namespace HelloTODO.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        TaskContext db = new TaskContext();

        public ActionResult Index()
        {
            IEnumerable<Task> tasks = db.Tasks.OrderByDescending(x => x.Priority).ThenBy(y => y.Id);
            return View(tasks);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Task add, HttpPostedFileBase File)
        {
            // получаем имя файла
            string fileName = Path.GetFileName(File.FileName);
            // сохраняем файл в папку Files в проекте
            File.SaveAs(Server.MapPath("~/Files/" + fileName));
            add.Image = fileName;

            db.Tasks.Add(add);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Task task = db.Tasks.Find(id);
            if (task != null)
            {
                FileInfo fi = new FileInfo(Server.MapPath("~\\files\\" + task.Image));
                ViewBag.FileInfo = fi;
                return View(task);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Task edited, HttpPostedFileBase File)
        {
            var oldTask = db.Tasks.Find(edited.Id);
            if (File.FileName != oldTask.Image)
            {
                System.IO.File.Delete(Server.MapPath("~/Files/" + oldTask.Image));
            }

            string fileName = Path.GetFileName(File.FileName);
            // сохраняем файл в папку Files в проекте
            File.SaveAs(Server.MapPath("~/Files/" + fileName));

            oldTask.Description = edited.Description;
            oldTask.Image = fileName;
            oldTask.Name = edited.Name;
            oldTask.Priority = edited.Priority;
            oldTask.Status = edited.Status;            

            //db.Entry(edited).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ShowDoneTasks()
        {
            // получаем из бд все объекты Task
            IEnumerable<Task> tasks = db.Tasks.Where(x => x.Status == true);
            tasks = tasks.OrderByDescending(x => x.Priority);
            // передаем все объекты в динамическое свойство Tasks в ViewBag
            ViewBag.Tasks = tasks;
            // возвращаем представление
            return View();
        }
        //////////////////////////////////////////////////////////////////
        //Subtasks
        //////////////////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult SubTaskDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Task task = db.Tasks.Include(t => t.SubTasks).FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }
        [HttpGet]
        public ActionResult AddSubtask()
        {
            // Формируем список команд для передачи в представление
            SelectList tasks = new SelectList(db.Tasks, "Id", "Name");
            ViewBag.Tasks = tasks;
            return View();
        }
        [HttpPost]
        public ActionResult AddSubtask(SubTask SubTask)
        {
            //Добавляем игрока в таблицу
            db.SubTasks.Add(SubTask);
            db.SaveChanges();
            // перенаправляем на главную страницу
            return RedirectToAction("Index");
        }
        //////////////////////////////////////////////////////////////////
        //Tags
        //////////////////////////////////////////////////////////////////
        [HttpGet]
        public ActionResult AddTag()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTag(Tag add)
        {
            db.Tags.Add(add);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}