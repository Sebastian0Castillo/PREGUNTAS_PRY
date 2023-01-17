
using Microsoft.EntityFrameworkCore;
using PREGUNTAS.Datalayer.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PREGUNTAS.DataLayer.DB.Entities.Seguridad;

namespace PREGUNTAS.DataLayer.DB.Context
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> options) : base(options)
        {

        }

        public DbSet<Pregunta> preguntas { get; set; }
        public DbSet<Respuesta> respuestas { get; set; }
        public DbSet<Seguridad_sesiones> sesiones { get; set; }
        public DbSet<Seguridad_usuarios> usuarios { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Seguridad_usuarios>(ent =>
            {
                ent.ToTable("security", "users");
            });

            builder.Entity<Seguridad_sesiones>(ent =>
            {
                ent.ToTable("security", "sessions");
                ent.HasIndex(p => p.Jti).IsUnique();
                ent.HasOne(p => p.user)
                .WithMany(p => p.history_sessions)
                .OnDelete(DeleteBehavior.Cascade);
            });


            builder.Entity<Pregunta>().ToTable("preguntas");
            builder.Entity<Respuesta>()
             .ToTable("Respuestas")
             .HasOne(e => e.IdPreguntaNavigation)
             .WithMany(e => e.id_Respuesta)
             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


