using Fiap.Api.Donation3.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.Donation3.Data
{
    public class DataContext : DbContext
    {

        public DbSet<CategoriaModel> Categorias { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Categoria
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
            #endregion

            #region Usuario
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.ToTable("Usuario");
                entity.HasKey(e => e.UsuarioId);

                entity.Property(e => e.UsuarioId).ValueGeneratedOnAdd();

                entity.Property(e => e.NomeUsuario)
                            .IsRequired()
                            .HasMaxLength(100);

                entity.Property(e => e.EmailUsuario)
                            .IsRequired()
                            .HasMaxLength(100);

                entity.Property(e => e.Senha)
                            .IsRequired()
                            .HasMaxLength(100);

                entity.Property(e => e.Regra)
                            .IsRequired()
                            .HasMaxLength(100);

            });


            modelBuilder.Entity<UsuarioModel>().HasData(
                new UsuarioModel(1, "admin@admin", "Admin", "admin123","admin"),
                new UsuarioModel(2, "fmoreni@gmail.com", "Flavio Moreni", "123456", "admin")
            );
            #endregion

        }

        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected DataContext()
        {
        }
    }
}
