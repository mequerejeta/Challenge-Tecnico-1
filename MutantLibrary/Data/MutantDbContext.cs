using Microsoft.EntityFrameworkCore;
using MutantDetection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutantDetection.Data
{
    public class MutantDbContext : DbContext
    {
        public MutantDbContext(DbContextOptions<MutantDbContext> options) : base(options) { }

        public DbSet<DnaRecord> DnaRecords { get; set; }
       
    }
}
