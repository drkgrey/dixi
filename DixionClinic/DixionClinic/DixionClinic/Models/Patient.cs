using System;
using System.Collections.Generic;
using System.Text;

namespace DixionClinic
{
    public class Patient
    {
        public int Id { get; set; }
        public int Phone { get; set; }
        public string AuthEmail { get; set; }
        public List<Visit> Visits { get; set; }
        public List<Profile> Profiles { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
