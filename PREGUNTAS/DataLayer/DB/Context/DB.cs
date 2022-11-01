using PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace PREGUNTAS.DataLayer.DB.Context
    {
        public class DB : DbContext
        {
            public DB(DbContextOptions<DB> options) : base(options)
            {

            }

            public DbSet<Preguntas> preguntas { get; set; }
            public DbSet<Respuestas> respuestas { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                 builder.Entity<Preguntas>().ToTable("preguntas");
                 builder.Entity<Respuestas>()
                 .ToTable("Respuestas")
                 .HasOne(e => e.preguntas)
                 .WithMany(e => e.respuestas)
                 .OnDelete(DeleteBehavior.Cascade);
        }
        }
    }


