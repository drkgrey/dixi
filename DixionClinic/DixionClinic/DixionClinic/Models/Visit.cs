using System;
using System.Collections.Generic;
using System.Text;

namespace DixionClinic
{
    public class Visit
    {
        public int Id { get; set; }
        public TimeSpan Hour { get; set; }
        public DateTime Day { get; set; }
        public int SpecialistId { get; set; }
        public int PatientId { get; set; }
    }
}
