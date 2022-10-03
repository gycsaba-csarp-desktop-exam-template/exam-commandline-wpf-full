using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceKretaLogger;
using Kreta.Models.Context;
using Kreta.Repositories;
using Kreta.Repositories.Interfaces;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Parameters;
using KretaWebApi.Controllers;
using KretaWebApi;
using KretaParancssoriAlkalmazas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Cryptography.X509Certificates;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using System.Collections;
using System.Runtime.ConstrainedExecution;

namespace KretaWebApiTest.Controllers.SubjectData
{
    public class SubjectsControllerPostTests
    {
        private readonly SubjectController controller;

        private Mock<ILoggerManager> mockLogger;
        private IMapper mapper;

        private static DbContextOptions<KretaContext> contextOptions = new DbContextOptionsBuilder<KretaContext>()
            .UseInMemoryDatabase(databaseName: "KretaTest")
            .Options;

        private KretaContext context;


        public SubjectsControllerPostTests()
        {

            mockLogger = new Mock<ILoggerManager>();
            // https://stackoverflow.com/questions/36074324/how-to-mock-an-automapper-imapper-object-in-web-api-tests-with-structuremap-depe
            //https://www.thecodebuzz.com/unit-test-mock-automapper-asp-net-core-imapper/
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper newMapper = mappingConfig.CreateMapper();
                mapper = newMapper;
            }
            context = new KretaContext(contextOptions);
            context.Subjects.AddRange(new List<EFSubject>());
        }

        private KretaContext MakeTestDatabaseWith3Data()
        {
            if (context.Subjects.Count() == 0)
            {
                List<EFSubject> subjectTableDataWith3Data = new List<EFSubject>
                {
                    new EFSubject { Id = 1, SubjectName="Tesi" },
                    new EFSubject { Id = 2, SubjectName="Tori" },
                    new EFSubject { Id = 3, SubjectName="Angol" },
                };
                context.Subjects?.AddRange(subjectTableDataWith3Data);
                context.SaveChanges();
            }
            return context;
        }

        // https://xunit.net/docs/getting-started/netfx/visual-studio
        // https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api
        // https://dotnetthoughts.net/how-to-unit-test-async-controllers-in-asp-net-5/
        // https://stackoverflow.com/questions/58234104/difficulties-using-inlinedata-in-unit-test-parameter-is-a-controller
        // https://www.anycodings.com/1questions/448002/unit-testing-controller-methods-which-return-iactionresult


        // Esetek
        // 1. Lehetséges
        // Hiba:
        // 2. Rövid a név
        // 3. Kicsi betűvel kezdődik a név
        // 4. Hosszabb mint harmincs a név
        // 5. Ékezeteket tartalmaz a név
        // 6. Nincs név

        //https://www.codegrepper.com/code-examples/csharp/xunit+inlinedata+but+declare+only+last+object
        //https://hamidmosalla.com/2017/02/25/xunit-theory-working-with-inlinedata-memberdata-classdata/
        //https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
        public class TestDataGenerator : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {
                  new SubjectForCreationDto
                  {
                        Id = 4,
                        SubjectName = "Magyar"
                  },
/*                  new SubjectForCreationDto
                  {
                        Id = 6,
                        SubjectName = "Magyar"
                  }*/
                };
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        [Theory]
        [ClassData(typeof(TestDataGenerator))]
        //[MemberData(nameof(TestDataGenerator.GetEnumerator),MemberType =typeof(TestDataGenerator))]
        public async void CreateSubjectPossible(SubjectForCreationDto newSubject)
        {
            //arrange            
            // Database with subject id: 1,2,3
            KretaContext context = MakeTestDatabaseWith3Data();

            SubjectService subjectService = new SubjectService(context);

            var controller = new SubjectController(mockLogger.Object, subjectService, mapper);

            if (context.Subjects != null)
            {
                // act
                var actionResult = await controller.CreateSubject(newSubject);

                // assert
               // Assert.NotNull(actionResult);
                //Assert.IsType<OkObjectResult>(actionResult);
                //var statusCodeReulst = (IStatusCodeActionResult)actionResult;
                //Assert.Equal(exptectedStatusCode, statusCodeReulst.StatusCode);
            }
        }
    }
}
