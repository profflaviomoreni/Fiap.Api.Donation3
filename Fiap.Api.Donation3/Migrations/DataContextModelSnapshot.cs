﻿// <auto-generated />
using System;
using Fiap.Api.Donation3.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fiap.Api.Donation3.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Api.Donation3.Models.CategoriaModel", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoriaId"));

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoriaId");

                    b.HasIndex("NomeCategoria")
                        .IsUnique();

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = 1,
                            NomeCategoria = "Celular"
                        },
                        new
                        {
                            CategoriaId = 2,
                            NomeCategoria = "Gadgets"
                        });
                });

            modelBuilder.Entity("Fiap.Api.Donation3.Models.ProdutoModel", b =>
                {
                    b.Property<int>("ProdutoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProdutoId"));

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SugestaoTroca")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<double>("Valor")
                        .HasPrecision(18, 2)
                        .HasColumnType("float(18)");

                    b.HasKey("ProdutoId");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("Fiap.Api.Donation3.Models.UsuarioModel", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UsuarioId"));

                    b.Property<string>("EmailUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Regra")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UsuarioId");

                    b.HasIndex("NomeUsuario")
                        .IsUnique();

                    b.ToTable("Usuario", (string)null);

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            EmailUsuario = "admin@admin",
                            NomeUsuario = "Admin",
                            Regra = "admin",
                            Senha = "admin123"
                        },
                        new
                        {
                            UsuarioId = 2,
                            EmailUsuario = "fmoreni@gmail.com",
                            NomeUsuario = "Flavio Moreni",
                            Regra = "admin",
                            Senha = "123456"
                        });
                });

            modelBuilder.Entity("Fiap.Api.Donation3.Models.ProdutoModel", b =>
                {
                    b.HasOne("Fiap.Api.Donation3.Models.CategoriaModel", "Categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Api.Donation3.Models.UsuarioModel", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
