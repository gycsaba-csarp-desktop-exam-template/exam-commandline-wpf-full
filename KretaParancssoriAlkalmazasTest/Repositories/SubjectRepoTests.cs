using Kreta.Models.Context;
using Kreta.Repositories;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace KretaParancssoriAlkalmazasTest.Repositories
{
    // https://github.com/etrupja/complete-guide-to-aspnetcore-web-api
    public class SubjectRepoTests
    {
        public static DbContextOptions<KretaContext> contextOptions = new DbContextOptionsBuilder<KretaContext>()
            .UseInMemoryDatabase(databaseName: "KretaTest")
            .Options;

        private ISortHelper<EFSubject> sortHelper;
        private IDataShaper<EFSubject> dataShaper;

        [SetUp]
        //[OneTimeSetUp]
        public void Setup()
        {
            // https://stackoverflow.com/questions/48061096/why-cant-i-call-the-useinmemorydatabase-method-on-dbcontextoptionsbuilder

            KretaContext context = new KretaContext(contextOptions);
            /*using (var context = new KretaContext(options))
            {
              
            }*/
            sortHelper = new SortHelper<EFSubject>();
            dataShaper = new DataShaper<EFSubject>();
            SubjectRepo subjectRepo = new SubjectRepo(context,sortHelper,dataShaper);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}