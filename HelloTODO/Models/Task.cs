using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloTODO.Models
{
    public class Task
    {
        // ID таска
        public int Id { get; set; }
        // Имя
        public string Name { get; set; }
        // Описание
        public string Description { get; set; }

        // Статус
        public bool Status { get; set; }
        // Priority
        public int Priority { get; set; }
        // Массив (лист (хешсет)) сабтасков
        public virtual ICollection<SubTask> SubTasks { get; set; } = new HashSet<SubTask>();
        // Массив (лист (хешсет)) тегов
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        // Прикреплённый файл
        public string Image { get; set; }
    }
}