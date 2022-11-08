
using Microsoft.EntityFrameworkCore;
using PREGUNTAS.Datalayer.DB;
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
            public DbSet<Pregunta> preguntas { get; set; }
            public DbSet<Respuesta> respuestas { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                 builder.Entity<Pregunta>().ToTable("preguntas");
                 builder.Entity<Respuesta>()
                 .ToTable("Respuestas")
                 .HasOne(e => e.IdPreguntaNavigation)
                 .WithMany(e => e.id_Respuesta)
                 .OnDelete(DeleteBehavior.Cascade);
        }
        }
    }


