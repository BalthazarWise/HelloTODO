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
        /// <summary>
        /// ID таска
        /// </summary>
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        // Имя
        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Название")]
        public string Name { get; set; }
        // Описание
        [Display(Name = "Описание")]
        public string Description { get; set; }
        // Email
        [Required(ErrorMessage = "Обязательное поле")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Некорректный адрес")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        // Deadline
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Deadline")]
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Deadline { get; set; }
        // Статус
        [Display(Name = "Статус")]
        public bool Status { get; set; }
        // Priority
        [Range(0, 10, ErrorMessage = "Приоритет может быть установлен от 0 до 10")]
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