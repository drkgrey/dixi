using System;
using System.Collections.Generic;
using System.Text;

namespace DixionClinic
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Category { get; set; }
        public byte[] Photo { get; set; }
        public Specialist[] Specialists { get; set; }
    }
}
