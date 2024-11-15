using MutantDetection.Data;
using MutantDetection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutantDetection.Seeders
{
    public static class DataSeeder
    {
        public static void SeedInitialData(MutantDbContext dbContext)
        {
            if (!dbContext.DnaRecords.Any())
            {
                dbContext.DnaRecords.AddRange(new List<DnaRecord>
            {
                new DnaRecord
                {
                    Dna = "ATGCGA,CAGTGC,TTATGT,AGAAGG,CCCCTA,TCACTG",
                    IsMutant = true
                },
                new DnaRecord
                {
                    Dna= "ATGCGA,CAGTGC,TTATTT,AGACGG,GCGTCA,TCACTG",
                    IsMutant = false
                },
                new DnaRecord
                {
                    Dna = "ATGCGA,CAGTGC,TTATGT,AGAAGG,CCCCAA,TCACTG",
                    IsMutant = true
                },
                new DnaRecord
                {
                    Dna = "ATGCGA,CAGTGC,TTATTT,AGACGG,GCGTCA,TCACTG",
                    IsMutant = false
                }
            });

                dbContext.SaveChanges();
            }
        }
    }
}
