using Fiap.Api.Donation3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation3.Data
{
    public class DataContext : DbContext
    {

        public DbSet<CategoriaModel> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Fluent API - EF
            modelBuilder.Entity<CategoriaModel>( entity =>
            {
                entity.ToTable("Categoria");
                
                entity.HasKey(e => e.CategoriaId);
                entity.Property(e => e.CategoriaId).ValueGeneratedOnAdd();

                entity.Property(e => e.NomeCategoria)
                            .IsRequired()
                            .HasMaxLength(50);

            } );


            // Criar tabela inserindos dados se estiver vázio
            modelBuilder.Entity<CategoriaModel>().HasData(
                new CategoriaModel() { CategoriaId = 1, NomeCategoria = "Celular"},
                new CategoriaModel() { CategoriaId = 2, NomeCategoria = "Gadgets" }
            );

        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
