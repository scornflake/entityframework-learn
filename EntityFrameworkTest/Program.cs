using EntityFrameworkTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using NLog;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using System;
using System.Windows.Forms;

namespace EntityFrameworkTest
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private string connectionString;

        public DataContextFactory(string connectString = "Host=localhost; Username=wft;Password=foo;Database=wft")
        {
            this.connectionString = connectString;
        }

        public DataContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<DataContext>();
            DbContextOptions<DataContext> options = (DbContextOptions<DataContext>)builder.UseNpgsql(connectionString).Options;
            return new DataContext(options, NLog.LogManager.GetCurrentClassLogger());
        }
    }

    static class Program
    {
        static readonly Container container;
        
        static Program()
        {
            container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SetupContainer();
            using (ThreadScopedLifestyle.BeginScope(container))
            {
                Application.Run(container.GetInstance<Form1>());
            }
        }

        private static void SetupContainer()
        {
            container.Register<DataContext>(
                () =>
                    {
                        return new DataContextFactory().CreateDbContext(new string[0]);
                    }
                , Lifestyle.Scoped);

            container.Register<ILogger>(() => LogManager.GetCurrentClassLogger());
            container.Verify();
        }
    }
}
