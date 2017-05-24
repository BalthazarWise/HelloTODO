using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloTODO.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tags { get; set; } = new HashSet<Task>();
    }
}