using LyncasAPI.Models;

namespace API.Admin
{
    public class Admin
    {
        private readonly ModelBuilder modelBuilder;

        public Admin(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void PopulaDB()
        {
            modelBuilder.Entity<Pessoa>().HasData(
             new Pessoa()
             {
                 IdPessoa = 1,
                 Nome = "Admin",
                 Sobrenome = "admin",
                 Email = "admin@admin.com",
                 Telefone = "4799999999",
                 DataDeNascimento = DateTime.ParseExact("2005-09-01", "yyyy-MM-dd", null),
             });
            modelBuilder.Entity<Autenticacao>().HasData(new Autenticacao()
            {
                UserId = 1,
                //senha do usuario 1 = admin123
                Senha = "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9",
                Status = true,
                IdPessoaAutenticacao = 1,
            });
        }
    }
}