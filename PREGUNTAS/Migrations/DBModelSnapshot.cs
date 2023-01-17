﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PREGUNTAS.DataLayer.DB.Context;

#nullable disable

namespace PREGUNTAS.Migrations
{
    [DbContext(typeof(DB))]
    partial class DBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas.Preguntas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcion_pregunta")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("id");

                    b.ToTable("preguntas", (string)null);
                });

            modelBuilder.Entity("PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas.Respuestas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descripcion_pregunta")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("id_pregunta")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("id_pregunta");

                    b.ToTable("Respuestas", (string)null);
                });

            modelBuilder.Entity("PREGUNTAS.DataLayer.DB.Entities.Seguridad.Seguridad_sesiones", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("Jti")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Jti")
                        .IsUnique();

                    b.HasIndex("user_id");

                    b.ToTable("security", "sessions");
                });

            modelBuilder.Entity("PREGUNTAS.DataLayer.DB.Entities.Seguridad.Seguridad_usuarios", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(80)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("id");

                    b.ToTable("security", "users");
                });

            modelBuilder.Entity("PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas.Respuestas", b =>
                {
                    b.HasOne("PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas.Preguntas", "preguntas")
                        .WithMany("respuestas")
                        .HasForeignKey("id_pregunta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("preguntas");
                });

            modelBuilder.Entity("PREGUNTAS.DataLayer.DB.Entities.Seguridad.Seguridad_sesiones", b =>
                {
                    b.HasOne("PREGUNTAS.DataLayer.DB.Entities.Seguridad.Seguridad_usuarios", "user")
                        .WithMany("history_sessions")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("PREGUNTAS.DataLayer.DB.Entities.Preguntas_Respuestas.Preguntas", b =>
                {
                    b.Navigation("respuestas");
                });

            modelBuilder.Entity("PREGUNTAS.DataLayer.DB.Entities.Seguridad.Seguridad_usuarios", b =>
                {
                    b.Navigation("history_sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
