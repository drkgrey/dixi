using System;
using System.Collections.Generic;
using System.Text;

namespace App4
{
    class Specialist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DepartmentId { get; set; }
        public int DoctorId { get; set; }
        public Visit Visit { get; set; }
    }
}
