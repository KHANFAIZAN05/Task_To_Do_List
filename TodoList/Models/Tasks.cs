using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TodoList.Controllers
{
    public class TaskList  
    {   [Key]
        
        public int TaskId { get; set; }
        
        [Required]
        [Display (Name ="Task Name")]
        public string TaskName { get; set; }

        [Required]
        [Display(Name = "Status")]
        public status TaskStatus { get; set; }

    }
    public enum status
    {
        Pending,
        Done
    }
}