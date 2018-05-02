using EntityFrameworkTest.Data;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using Testing;
using Xunit;
using Xunit.Abstractions;

namespace OrganizationTests
{
    public class Organizations : ContainerTest
    {
        public Organizations(ITestOutputHelper output) : base(output) { }

        [Fact]
        public void CanCreateOrg()
        {
            Console.WriteLine("Creating org");

            Organization org = new Organization();
            Assert.NotNull(org);
            //Assert.NotNull(org.Created);
        }
    }

    /*
     * The inheritance from DatabaseTest doesn't do much (DatabaseTest is mostly commented out)
     * See this tests constructor
    */
    public class OrgDBTest : DatabaseTest
    {
        public OrgDBTest(ITestOutputHelper output) : base(output)
        {
            string connectionString = "Host=localhost; Username=wft; Password=foo; Database=wft";

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<DataContext>();

            /*
             * This is where it's failing
             */
            DbContextOptions<DataContext> options = (DbContextOptions<DataContext>)builder.UseNpgsql(connectionString).Options;

            //new DataContext(options, NLog.LogManager.GetCurrentClassLogger());

        }

        [Fact]
        public void CanWriteOrgToDb()
        {
            /*
             * Commented out for now while I solve the DbContext problem
             */
            //Organization org = new Organization();
            //org.Name = "super org!";
            //Database.SaveChanges();

        }
    }
}

