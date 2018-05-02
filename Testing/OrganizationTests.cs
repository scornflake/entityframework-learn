using EntityFrameworkTest.Data;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
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

    public class OrgDBTest : DatabaseTest
    {
        public OrgDBTest(ITestOutputHelper output) : base(output)
        {
            string connectionString = "Host=localhost; Username=wft; Password=foo; Database=wft";
            //DbProviderFactory f = DbProviderFactories.GetFactory("WFT");
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder<DataContext>();
            DbContextOptions<DataContext> options = (DbContextOptions<DataContext>)builder.UseNpgsql(connectionString).Options;
            //new DataContext(options, NLog.LogManager.GetCurrentClassLogger());

        }

        [Fact]
        public void CanWriteOrgToDb()
        {
            Organization org = new Organization();
            org.Name = "shinywhitebox";

            //Database.SaveChanges();

        }
    }
}

