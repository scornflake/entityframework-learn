using EntityFrameworkTest;
using EntityFrameworkTest.Data;
using NUnit.Framework;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Testing
{
    public class ContainerTest
    {
        public ContainerTest()
        {
            this.container = new Container();
            container.Options.DefaultScopedLifestyle = new ThreadScopedLifestyle();
        }
        public Container container { get; private set; }
    }

    public class DatabaseTest : ContainerTest
    {
        public DatabaseTest()
        {
            string testConnectionString = "Host=localhost; Username=wft;Password=foo;Database=wft-test";
            container.Register<DataContext>(
                () =>
                {
                    return new DataContextFactory(testConnectionString).CreateDbContext(new string[0]);
                }, Lifestyle.Scoped);
            container.Verify();
        }

        [OneTimeSetUp]
        public void DBInit()
        {
            // Get the context from the container and ensure migrations
            using(ThreadScopedLifestyle.BeginScope(container))
            {
                this.Database.Migrate();
            }
        }

        [OneTimeTearDown]
        public void DBDestroy()
        {
            using (ThreadScopedLifestyle.BeginScope(container))
            {
                this.Database.Database.EnsureDeleted();
            }
        }

        public DataContext Database
        {
            get { return this.container.GetInstance<DataContext>(); }
        }
    }
}
