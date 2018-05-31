using System;
using System.Collections.Generic;
using System.Text;

namespace DixionClinic
{
    public class Direction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Department[] Departments { get; set; }
    }
}
