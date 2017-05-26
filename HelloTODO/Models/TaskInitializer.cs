using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HelloTODO.Models
{
    public class TaskInitializer : CreateDatabaseIfNotExists<TaskContext>
    {
        protected override void Seed(TaskContext db)
        {
            var t1 = new Task
            {
                Id = 1,
                Name = "Сходить в магазин",
                Description = "Задача - купить еды на ужин, бюджет - 30грн.",
                Email = "hochukushat@barabaka.gov",
                Deadline = DateTime.Now.AddDays(2),
                Status = true,  Priority = 3, Image = "Homer.png"
            };
            var t2 = new Task
            {
                Id = 2,
                Name = "Чекнуть 2ч",
                Description = "Проверить борды, вдруг там новый цуинь тред",
                Email = "anonis@2ch.hk",
                Deadline = DateTime.Now.AddDays(3),
                Status = false, Priority = 2, Image = "Mammoth.png"
            };
            var t3 = new Task
            {
                Id = 3,
                Name = "Приготовить еду",
                Description = "Надо бы еды приготовить, а то одними бутербродами питаюсь",
                Email = "coock@salo.org",
                Deadline = DateTime.Now.AddDays(1),
                Status = true,  Priority = 3, Image = "Pepe.png"
            };
            var t4 = new Task
            {
                Id = 4,
                Name = "Погладить кота",
                Description = "Кот грустит. Погладь его.",
                Email = "kisa@gmail.com",
                Deadline = DateTime.Now.AddDays(3),
                Status = false, Priority = 1, Image = "Salo.png"
            };

            db.Tasks.Add(t1);
            db.Tasks.Add(t2);
            db.Tasks.Add(t3);
            db.Tasks.Add(t4);

            var tg1 = new Tag { Id = 1, Name = "Вне дома",         Tags = new HashSet<Task>() { t1 } };
            var tg2 = new Tag { Id = 1, Name = "Дома",             Tags = new HashSet<Task>() { t2, t3, t4 } };
            var tg3 = new Tag { Id = 1, Name = "Приносит радость", Tags = new HashSet<Task>() { t2, t4 } };

            db.Tags.Add(tg1);
            db.Tags.Add(tg2);
            db.Tags.Add(tg3);

            var sb1 = new SubTask { SubTaskId = 1, Name = "Одется",                Order = 1, Task = t1, TaskId = 1 };
            var sb2 = new SubTask { SubTaskId = 2, Name = "Пойти в магазин",       Order = 2, Task = t1, TaskId = 1 };
            var sb3 = new SubTask { SubTaskId = 3, Name = "Вернуться",             Order = 3, Task = t1, TaskId = 1 };
            var sb4 = new SubTask { SubTaskId = 4, Name = "Наслаждаться мемасами", Order = 1, Task = t2, TaskId = 2 };

            db.SubTasks.Add(sb1);
            db.SubTasks.Add(sb2);
            db.SubTasks.Add(sb3);
            db.SubTasks.Add(sb4);

            base.Seed(db);
        }
    }
}