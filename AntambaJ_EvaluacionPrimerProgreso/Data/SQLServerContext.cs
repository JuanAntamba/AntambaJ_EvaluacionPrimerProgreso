using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AntambaJ_EvaluacionPrimerProgreso.Models;

    public class SQLServerContext : DbContext
    {
        public SQLServerContext (DbContextOptions<SQLServerContext> options)
            : base(options)
        {
        }

        public DbSet<AntambaJ_EvaluacionPrimerProgreso.Models.Mascota> Mascota { get; set; } = default!;

public DbSet<AntambaJ_EvaluacionPrimerProgreso.Models.CitaVeterinaria> CitaVeterinaria { get; set; } = default!;

public DbSet<AntambaJ_EvaluacionPrimerProgreso.Models.Propietario> Propietario { get; set; } = default!;
    }
