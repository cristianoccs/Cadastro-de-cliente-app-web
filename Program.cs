using Cad_Cliente.Dados;
using Cad_Cliente.Integracao.Interfece;
using Cad_Cliente.Integracao.Refit;
using Cad_Cliente.Repositorio;
using CadastroCliente.Integracao;
using Microsoft.EntityFrameworkCore;
using Refit;

namespace Cad_Cliente
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
            builder.Services.AddScoped<Icadastro, CadastroRepositorio>();
            builder.Services.AddScoped<IviaCepIntegracao, ViaCepIntegracao>();
            builder.Services.AddRefitClient<IcepRefit>().ConfigureHttpClient(c => { c.BaseAddress = new Uri("https://viacep.com.br"); });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
