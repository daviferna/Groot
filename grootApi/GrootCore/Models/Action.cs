using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrootCore.Models
{
    public class Action
    {
        public Action() { }

        public int ActionId { get; set; }
        public string ActionContent { get; set; }
        public bool Done { get; set; }

        public Groot Groot { get; set; }
    }
}
