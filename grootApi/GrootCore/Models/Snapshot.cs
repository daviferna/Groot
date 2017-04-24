using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrootCore.Models
{
    public class Snapshot
    {
        public Snapshot() { }
        public int SnapshotId { get; set; }
        public string Data { get; set; }
        public Groot Groot;

    }
}
