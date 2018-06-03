using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace App4
{
    class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Info { get; set; }
        public string Category { get; set; }
        public byte[] Photo { get; set; }
        public Specialist Specialist { get; set; }
    }
}
