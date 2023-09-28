using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ConsoleApp1
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
        }

        private static ServiceProvider CriandoServicoSql()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb=> rb
                .AddSqlServer2016()
                .WithGlobalConnectionString("Data Source=localhost;Initial Catalog=Cliente;Integrated Security=SSPI;TrustServerCertificate=True;User ID=sa;Password=Sap@123")
                .ScanIn(typeof(MigracaoTabelaCliente).Assembly).For.Migrations())
                .AddLogging(lb=> lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
