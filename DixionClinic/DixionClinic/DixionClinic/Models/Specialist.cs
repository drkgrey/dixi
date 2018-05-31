using System;
using System.Collections.Generic;
using System.Text;

namespace DixionClinic
{
    public class Specialist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartamentId { get; set; } = 1;
        public int DoctorId { get; set; }
        public Visit[] Visits { get; set; }
    }
}
