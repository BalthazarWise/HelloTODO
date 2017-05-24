using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloTODO.Models
{
    public class Task
    {
        // ID таска
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        // Имя
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }
        // Описание
        [Display(Name = "Описание")]
        public string Description { get; set; }
        // Email
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        // Deadline
        [Required]
        [Display(Name = "Deadline")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }
        // Статус
        [Display(Name = "Статус")]
        public bool Status { get; set; }
        // Priority
        [Display(Name = "Приоритет")]
        public int Priority { get; set; }
        // Массив (лист (хешсет)) сабтасков
        public virtual ICollection<SubTask> SubTasks { get; set; } = new HashSet<SubTask>();
        // Массив (лист (хешсет)) тегов
        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
        // Прикреплённый файл
        public string Image { get; set; }
    }
}