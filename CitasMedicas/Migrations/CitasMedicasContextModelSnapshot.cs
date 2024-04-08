﻿// <auto-generated />
using System;
using CitasMedicas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CitasMedicas.Migrations
{
    [DbContext(typeof(CitasMedicasContext))]
    partial class CitasMedicasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.HasSequence("UsuarioSequence");

            modelBuilder.Entity("CitasMedicas.Models.Cita", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attribute11")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FechaHora")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicoId")
                        .HasColumnType("int");

                    b.Property<string>("MotivoCita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PacienteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("Citas", (string)null);
                });

            modelBuilder.Entity("CitasMedicas.Models.Diagnostico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CitaId")
                        .HasColumnType("int");

                    b.Property<string>("Enfermedad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValoracionEspecialista")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CitaId")
                        .IsUnique();

                    b.ToTable("Diagnosticos", (string)null);
                });

            modelBuilder.Entity("CitasMedicas.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR [UsuarioSequence]");

                    SqlServerPropertyBuilderExtensions.UseSequence(b.Property<int>("Id"));

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("MedicoPaciente", b =>
                {
                    b.Property<int>("MedicosId")
                        .HasColumnType("int");

                    b.Property<int>("PacientesId")
                        .HasColumnType("int");

                    b.HasKey("MedicosId", "PacientesId");

                    b.HasIndex("PacientesId");

                    b.ToTable("MedicoPaciente");
                });

            modelBuilder.Entity("CitasMedicas.Models.Medico", b =>
                {
                    b.HasBaseType("CitasMedicas.Models.Usuario");

                    b.Property<string>("NumColegiado")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("CitasMedicas.Models.Paciente", b =>
                {
                    b.HasBaseType("CitasMedicas.Models.Usuario");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NSS")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumTarjeta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("CitasMedicas.Models.Cita", b =>
                {
                    b.HasOne("CitasMedicas.Models.Medico", "Medico")
                        .WithMany("ListaCitasMedico")
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CitasMedicas.Models.Paciente", "Paciente")
                        .WithMany("ListaCitasPaciente")
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("CitasMedicas.Models.Diagnostico", b =>
                {
                    b.HasOne("CitasMedicas.Models.Cita", "Cita")
                        .WithOne("Diagnostico")
                        .HasForeignKey("CitasMedicas.Models.Diagnostico", "CitaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cita");
                });

            modelBuilder.Entity("MedicoPaciente", b =>
                {
                    b.HasOne("CitasMedicas.Models.Medico", null)
                        .WithMany()
                        .HasForeignKey("MedicosId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("CitasMedicas.Models.Paciente", null)
                        .WithMany()
                        .HasForeignKey("PacientesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CitasMedicas.Models.Cita", b =>
                {
                    b.Navigation("Diagnostico");
                });

            modelBuilder.Entity("CitasMedicas.Models.Medico", b =>
                {
                    b.Navigation("ListaCitasMedico");
                });

            modelBuilder.Entity("CitasMedicas.Models.Paciente", b =>
                {
                    b.Navigation("ListaCitasPaciente");
                });
#pragma warning restore 612, 618
        }
    }
}
