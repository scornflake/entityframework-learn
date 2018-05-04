using EntityFrameworkTest.Data;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SimpleInjector.Lifestyles;
using Testing;

namespace OrganizationTests
{
    public class Organizations : ContainerTest
    {
        [Test]
        public void CanCreateOrg()
        {
            System.Console.WriteLine("Creating org");

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
        [Test]
        public void CanWriteOrgToDb()
        {
            using (ThreadScopedLifestyle.BeginScope(container))
            {
                var db = Database;
                Organization org = new Organization();
                org.Name = "super org!";
                db.Organizations.Add(org);
                db.SaveChanges();
            }
        }
    }
}

