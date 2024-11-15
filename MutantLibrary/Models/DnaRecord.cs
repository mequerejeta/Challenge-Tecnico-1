using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutantDetection.Models
{
    public class DnaRecord
    {
        public int Id { get; set; }
        public string Dna { get; set; } = null!;
        public bool IsMutant { get; set; }
    }
}
