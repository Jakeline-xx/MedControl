﻿// <auto-generated />
using System;
using MedControl.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MedControl.Migrations
{
    [DbContext(typeof(MedControlDbContext))]
    [Migration("20231118020738_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MedControl.Models.Departamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Departamento", (string)null);
                });

            modelBuilder.Entity("MedControl.Models.Estoque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdMedicamento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("QuantidadeDisponivel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdMedicamento")
                        .IsUnique();

                    b.ToTable("Estoque", (string)null);
                });

            modelBuilder.Entity("MedControl.Models.Funcionario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("IdDepartamento")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdUnidadeTrabalho")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartamento");

                    b.HasIndex("IdUnidadeTrabalho");

                    b.ToTable("Funcionario", (string)null);
                });

            modelBuilder.Entity("MedControl.Models.Medicamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Medicamento", (string)null);
                });

            modelBuilder.Entity("MedControl.Models.Transacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataTransacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdEstoque")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdFuncionario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdEstoque");

                    b.HasIndex("IdFuncionario");

                    b.ToTable("Transacao", (string)null);
                });

            modelBuilder.Entity("MedControl.Models.UnidadeTrabalho", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("UnidadeTrabalho", (string)null);
                });

            modelBuilder.Entity("MedControl.Models.Estoque", b =>
                {
                    b.HasOne("MedControl.Models.Medicamento", "Medicamento")
                        .WithOne("Estoque")
                        .HasForeignKey("MedControl.Models.Estoque", "IdMedicamento")
                        .IsRequired();

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("MedControl.Models.Funcionario", b =>
                {
                    b.HasOne("MedControl.Models.Departamento", "Departamento")
                        .WithMany("Funcionarios")
                        .HasForeignKey("IdDepartamento")
                        .IsRequired();

                    b.HasOne("MedControl.Models.UnidadeTrabalho", "UnidadeTrabalho")
                        .WithMany("Funcionarios")
                        .HasForeignKey("IdUnidadeTrabalho")
                        .IsRequired();

                    b.Navigation("Departamento");

                    b.Navigation("UnidadeTrabalho");
                });

            modelBuilder.Entity("MedControl.Models.Transacao", b =>
                {
                    b.HasOne("MedControl.Models.Estoque", "Estoque")
                        .WithMany("Transacoes")
                        .HasForeignKey("IdEstoque")
                        .IsRequired();

                    b.HasOne("MedControl.Models.Funcionario", "Funcionario")
                        .WithMany("Transacoes")
                        .HasForeignKey("IdFuncionario")
                        .IsRequired();

                    b.Navigation("Estoque");

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("MedControl.Models.Departamento", b =>
                {
                    b.Navigation("Funcionarios");
                });

            modelBuilder.Entity("MedControl.Models.Estoque", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("MedControl.Models.Funcionario", b =>
                {
                    b.Navigation("Transacoes");
                });

            modelBuilder.Entity("MedControl.Models.Medicamento", b =>
                {
                    b.Navigation("Estoque");
                });

            modelBuilder.Entity("MedControl.Models.UnidadeTrabalho", b =>
                {
                    b.Navigation("Funcionarios");
                });
#pragma warning restore 612, 618
        }
    }
}
