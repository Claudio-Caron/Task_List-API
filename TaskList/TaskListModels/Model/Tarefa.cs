using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskList.Data.Model
{
    public class Tarefa
    {
        
        public int Id { get; set; }
        public bool IsCompleted { get; set; }=false;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateOnly DateTask { get; set; }
    }
}
