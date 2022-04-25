using API.Admin;
using LyncasAPI.Models;

namespace LyncasAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Pessoa> Pessoa { get; set; }

        public DbSet<Autenticacao> Autenticacao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Autenticacao>().HasOne(p => p.User)
                .WithOne(p => p.autenticacao)
                .HasForeignKey<Autenticacao>(p => p.UserId);
            modelBuilder.Entity<Pessoa>()
               .HasIndex(p => p.Email)
               .IsUnique();

            new Admin(modelBuilder).PopulaDB();
        }


    }
}