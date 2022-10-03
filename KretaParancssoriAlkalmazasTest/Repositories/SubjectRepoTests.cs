using Kreta.Models.Context;
using Kreta.Repositories;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace KretaParancssoriAlkalmazasTest.Repositories
{
    // https://github.com/etrupja/complete-guide-to-aspnetcore-web-api
    public class SubjectRepoTests
    {
        public static DbContextOptions<KretaContext> contextOptions = new DbContextOptionsBuilder<KretaContext>()
            .UseInMemoryDatabase(databaseName: "KretaTest"+Guid.NewGuid().ToString())
            .Options;

        private ISortHelper<EFSubject> sortHelper;
        private IDataShaper<EFSubject> dataShaper;
        private KretaContext context;
        private SubjectRepo subjectRepo;

        //[SetUp]
        [OneTimeSetUp]
        public void Setup()
        {
            context = new KretaContext(contextOptions);
            sortHelper = new SortHelper<EFSubject>();
            dataShaper = new DataShaper<EFSubject>();
            subjectRepo = new SubjectRepo(context);
        }   

        [OneTimeTearDown]
        public void CleanUp()
        {
            context.Database.EnsureDeleted();
        }

        private void ClearSubjects()
        {
            foreach (var entity in context.Subjects)
            {
                context.Subjects.Remove(entity);
            }
            context.SaveChanges();
        }

        private KretaContext MakeTestDatabaseWith3Data()
        {
            ClearSubjects(); ;
            List<EFSubject> subjectTableDataWith3Data = new List<EFSubject>
                {
                    new EFSubject { Id = 1, SubjectName="Tesi" },
                    new EFSubject { Id = 2, SubjectName="Tori" },
                    new EFSubject { Id = 3, SubjectName="Angol" },
                };
            context.Subjects?.AddRange(subjectTableDataWith3Data);
            context.SaveChanges();

            return context;
        }

        // Van subject
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SubjectGetByIdOk(int exptectedId)
        {
            MakeTestDatabaseWith3Data();
            if (subjectRepo != null)
            {
                EFSubject subject = subjectRepo.GetSubjectById(exptectedId);
                if (subject != null)
                {
                    Assert.IsNotNull(subject, "SubjectRepo:GetSubjectById->Létezõ tantárgyat id alapján nem talál meg.");
                    Assert.AreEqual(exptectedId, subject.Id, "SubjectRepo:GetSubjectById->Létezõ tantárgyak esetén a megtalált id-je nem a keresett!");
                }
            }
        }

        // Nincs subject
        [Test]
        [TestCase(0)]
        [TestCase(4)]
        [TestCase(5)]
        public void SubjectGetByIdNoSubject(int exptectedId)
        {
            MakeTestDatabaseWith3Data();
            if (subjectRepo != null)
            {
                EFSubject subject = subjectRepo.GetSubjectById(exptectedId);
                Assert.IsNull(subject, "SubjectRepo:GetSubjectById->Nem létezõ id-jú tantárgyak megtalál");
            }
        }

        // Nincs subject
        [Test]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(5)]
        public void SubjectGetByIdEmptyRepo(int exptectedId)
        {           
            if (subjectRepo != null)
            {
                EFSubject subject = subjectRepo.GetSubjectById(exptectedId);
                Assert.IsNull(subject, "SubjectRepo:GetSubjectById->Üres tantárgy repo esetén talál adatot");
            }
        }
    }
}