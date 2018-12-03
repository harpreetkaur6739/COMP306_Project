using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _300910377_KAUR__300916412_YANG__Project.Models
{
    public class PatientEHRContext : DbContext
{
        public PatientEHRContext(DbContextOptions<PatientEHRContext> options) : base(options) { }

        public DbSet<PatientEHR> PatientEHR { get; set; }
}
}
