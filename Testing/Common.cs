using EntityFrameworkTest;
using EntityFrameworkTest.Data;
using SimpleInjector;
using System.Data.Common;
using Xunit.Abstractions;

namespace Testing
{
    public class ContainerTest
    {
        private ITestOutputHelper output;

        public ContainerTest(ITestOutputHelper output)
        {
            this.output = output;
            this.container = new Container();
        }

        public ITestOutputHelper Console
        {
            get { return output; }
        }

        public Container container { get; private set; }
    }

    public class DatabaseTest : ContainerTest
    {
        public DatabaseTest(ITestOutputHelper output) : base(output)
        {
            string testConnectionString = "Host=localhost; Username=wft;Password=foo;Database=wft-test";
            //container.Register<DataContext>(
            //    () =>
            //    {
            //        return new DataContextFactory(testConnectionString).CreateDbContext(new string[0]);
            //    }
            //    , Lifestyle.Singleton);
        }

        public DataContext Database
        {
            get { return this.container.GetInstance<DataContext>(); }
        }
    }
}
