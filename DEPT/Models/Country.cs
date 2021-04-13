using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEPT.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Code { get; set; }

        public DateTime FirstUpdated { get; set; }

        public DateTime LastUpdated { get; set; }

        IEnumerable<Parameters> Parameters { get; set; }

        public double Count { get; set; }

        public int Cities { get; set; }

        public int Sources { get; set; }


    }
}
