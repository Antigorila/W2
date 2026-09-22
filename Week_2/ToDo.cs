using System;
using System.Collections.Generic;
using System.Text;

namespace Week_2
{
    public class ToDo
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public bool IsUrgent { get; set; }
    }
}
