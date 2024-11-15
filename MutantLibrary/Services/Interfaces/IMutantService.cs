using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutantDetection.Services.Interfaces
{
    public interface IMutantService
    {
        bool IsMutant(string[] dna);
    }
}
