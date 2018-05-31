using System;
using System.Collections.Generic;
using System.Text;

namespace DixionClinic
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DirectionId { get; set; }
        public Specialist[] Specialists { get; set; }
    }
}
