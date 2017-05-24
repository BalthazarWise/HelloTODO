using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelloTODO.Models
{
    
    public class SubTask
    {
        [Key]
        public int SubTaskId { get; set; }
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}