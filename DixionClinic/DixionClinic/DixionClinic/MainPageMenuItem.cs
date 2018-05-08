using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DixionClinic
{

    public class MainPageMenuItem
    {
        public MainPageMenuItem()
        {
            TargetType = typeof(News);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}