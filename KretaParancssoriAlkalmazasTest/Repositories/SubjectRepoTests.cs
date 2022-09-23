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
        private KretaContext context;
        private SubjectRepo subjectRepo;

        [SetUp]
        //[OneTimeSetUp]
        public void Setup()
        {
            // https://stackoverflow.com/questions/48061096/why-cant-i-call-the-useinmemorydatabase-method-on-dbcontextoptionsbuilder

             context = new KretaContext(contextOptions);
            /*using (var context = new KretaContext(options))
            {
              
            }*/
            sortHelper = new SortHelper<EFSubject>();
            dataShaper = new DataShaper<EFSubject>();
            subjectRepo = new SubjectRepo(context,sortHelper,dataShaper);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        [TestCase(1, 1)]
        public void SubjectGetByIdOk(int exptectedId, int actualId)
        {
            var subjects = new List<EFSubject>
            {
                new EFSubject { Id = 1, SubjectName="Tesi" },
                new EFSubject { Id = 2, SubjectName="Tori" },
                new EFSubject { Id = 3, SubjectName="Angol" },
            };
            context.AddRange(subjects);
            context.SaveChanges();
            EFSubject subject=subjectRepo.GetSubjectById(actualId);
            Assert.IsNotNull(subject,"SubjectRepo:GetSubjectById->Jó adat esetén null");
            Assert.AreEqual(exptectedId, actualId, "SubjectRepo:GetSubjectById->Jó adat esetén nem megfelelõ id-t ad vissza.");                 
            Assert.Pass();
        }
    }
}