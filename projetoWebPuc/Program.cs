using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace projetoWebPuc
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using(var serviceProvider = CriandoServicoSql())
                using(var escopo = serviceProvider.CreateScope())
            {
                UpdateDatabase(escopo.ServiceProvider);
            }


            var builderBanco = criaHostBuilder();
            var servicesProvider = builderBanco.Build().Services;
            var repositorio = servicesProvider.GetService<InterfaceCliente>();

        }

        private static ServiceProvider CriandoServicoSql()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb=> rb
                .AddSqlServer2016()
                .WithGlobalConnectionString("server=localhost;database=Cliente;User ID=sa;Password=Sap@123")
                .ScanIn(typeof(MigracaoTabelaCliente).Assembly).For.Migrations())
                .AddLogging(lb=> lb.AddFluentMigratorConsole())
                .BuildServiceProvider();
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }

        static IHostBuilder criaHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<InterfaceCliente, RepositorioBancoDeDados>();
                });
        }
    }
}
