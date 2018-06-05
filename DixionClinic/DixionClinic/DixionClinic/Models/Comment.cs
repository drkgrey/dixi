using System;
using System.Collections.Generic;
using System.Text;

namespace DixionClinic
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SpecialistID { get; set; }
        public int PatientId { get; set; }
    }
}
