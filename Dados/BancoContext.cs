using Cad_Cliente.Models;
using Microsoft.EntityFrameworkCore;

namespace Cad_Cliente.Dados
{
    public class BancoContext : DbContext 
    {
        public BancoContext(DbContextOptions<BancoContext>options) : base(options) 
        { }

        public DbSet<CadastroModel> CadastroTabela { get; set; }
    }
}
