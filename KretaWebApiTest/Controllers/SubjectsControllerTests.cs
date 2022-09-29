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

namespace KretaWebApiTest.Controllers
{
    public class SubjectsControllerTests
    {
        private readonly SubjectController controller;

        private Mock<ILoggerManager> mockLogger;
        private IMapper mapper;

        public static DbContextOptions<KretaContext> contextOptions = new DbContextOptionsBuilder<KretaContext>()
            .UseInMemoryDatabase(databaseName: "KretaTest")
            .Options;

        // Test database;
        List<Subject> subjectTableDataWith3Data;

        public SubjectsControllerTests()
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

        }

        private void MakeTestDatabase()
        {
            KretaContext context = new KretaContext(contextOptions);
            subjectTableDataWith3Data = new List<EFSubject>
            {
                new EFSubject { Id = 1, SubjectName="Tesi" },
                new EFSubject { Id = 2, SubjectName="Tori" },
                new EFSubject { Id = 3, SubjectName="Angol" },
            };
            context.Subjects.AddRange(subjectTableData);
            context.SaveChanges();
        }

        // https://xunit.net/docs/getting-started/netfx/visual-studio
        // https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api
        // https://dotnetthoughts.net/how-to-unit-test-async-controllers-in-asp-net-5/
        // https://stackoverflow.com/questions/58234104/difficulties-using-inlinedata-in-unit-test-parameter-is-a-controller
        // https://www.anycodings.com/1questions/448002/unit-testing-controller-methods-which-return-iactionresult

        [Theory]
        [InlineData(1,StatusCodes.Status200OK)]
        [InlineData(2, StatusCodes.Status200OK)]
        [InlineData(3,StatusCodes.Status200OK)]
        public async void GetReturnSubjectSameId(int exptectedElementIid, int exptectedCode )
        {
            FieldsParameter fieldsParameter = new FieldsParameter();

            

            

            SubjectService subjectService = new SubjectService(context);


            //arrange
            EFSubject exptedtedSubject = subjectTableData.Where(subject => subject.Id.Equals(exptectedElementIid)).FirstOrDefault();
            var controller = new SubjectController(mockLogger.Object, subjectService, mapper);

            // act
            var actionResult = await controller.GetSubjectById(exptectedElementIid, fieldsParameter);

            // assert
            Assert.NotNull(actionResult);
            var objectResult = actionResult as OkObjectResult;
            Assert.NotNull(objectResult);
            Assert.IsType<Subject>(objectResult.Value);
            var modelResult = objectResult.Value as Subject;

            Assert.NotNull(modelResult);
            Assert.Equal(exptedtedSubject.Id, modelResult.Id);
            Assert.Equal(exptedtedSubject.SubjectName, modelResult.SubjectName);

            var statusCodeReulst = (IStatusCodeActionResult)(actionResult);
            Assert.Equal(exptectedCode, statusCodeReulst.StatusCode);

        }
    }
}
