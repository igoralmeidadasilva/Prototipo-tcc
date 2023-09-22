using System;
using Microsoft.EntityFrameworkCore;
using tcc.api.Models;

namespace tcc.api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<NamedEntityModel> NamedEntities { get; set; }
        public DbSet<EntityModel> Entities { get; set; }
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // // Configurar a chave primária da classe EntityModel
            // modelBuilder.Entity<EntityModel>()
            //     .HasKey(e => e.CodEntidade);

            // // Configurar a relação entre NamedEntityModel e EntityModel
            // modelBuilder.Entity<NamedEntityModel>()
            //     .HasOne(ne => ne.Entidade)          // NamedEntityModel possui uma Entidade
            //     .WithMany()                         // EntityModel não possui uma coleção de NamedEntityModel
            //     .HasForeignKey(ne => ne.CodEntidade) // Chave estrangeira usando a propriedade de navegação Entidade
            //     .IsRequired(false);
        }
    }
}
