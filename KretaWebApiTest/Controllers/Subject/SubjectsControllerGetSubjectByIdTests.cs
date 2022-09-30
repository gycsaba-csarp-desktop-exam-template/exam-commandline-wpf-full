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

namespace KretaWebApiTest.Controllers.Subject
{
    public class SubjectsControllerGetSubjectByIdTests
    {
        private readonly SubjectController controller;

        private Mock<ILoggerManager> mockLogger;
        private IMapper mapper;

        private static DbContextOptions<KretaContext> contextOptions = new DbContextOptionsBuilder<KretaContext>()
            .UseInMemoryDatabase(databaseName: "KretaTest")
            .Options;

        private KretaContext context;


        public SubjectsControllerGetSubjectByIdTests()
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
                //context = new KretaContext(contextOptions);
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

        [Theory]
        [InlineData(1, StatusCodes.Status200OK)]
        [InlineData(2, StatusCodes.Status200OK)]
        [InlineData(3, StatusCodes.Status200OK)]
        public async void GetReturnSubjectStatus200Ok(int exptectedElementIid, int exptectedStatusCode)
        {
            //arrange            
            // Database with subject id: 1,2,3
            KretaContext context = MakeTestDatabaseWith3Data();

            SubjectService subjectService = new SubjectService(context);
            FieldsParameter fieldsParameter = new FieldsParameter();

            var controller = new SubjectController(mockLogger.Object, subjectService, mapper);

            if (context.Subjects != null)
            {
                // act
                EFSubject exptedtedSubject = context.Subjects.Where(subject => subject.Id.Equals(exptectedElementIid)).FirstOrDefault();
                if (exptedtedSubject != null)
                {
                    var actionResult = await controller.GetSubjectById(exptectedElementIid, fieldsParameter);

                    // assert
                    Assert.NotNull(actionResult);
                    Assert.IsType<OkObjectResult>(actionResult);
                    var statusCodeReulst = (IStatusCodeActionResult)actionResult;
                    Assert.Equal(exptectedStatusCode, statusCodeReulst.StatusCode);


                    var objectResult = actionResult as OkObjectResult;
                    Assert.NotNull(objectResult);
                    if (objectResult != null)
                    {

                        Assert.IsType<Subject>(objectResult.Value);
                        var modelResult = objectResult.Value as Subject;
                        if (modelResult != null)
                        {
                            Assert.NotNull(modelResult);
                            Assert.Equal(exptedtedSubject.Id, modelResult.Id);
                            Assert.Equal(exptedtedSubject.SubjectName, modelResult.SubjectName);
                        }
                    }
                }
            }
        }

        [Theory]
        [InlineData(5, StatusCodes.Status400BadRequest)]
        [InlineData(0, StatusCodes.Status400BadRequest)]
        public async void GetReturnSubjectStatus400BadRequest(int exptectedElementIid, int exptectedStatusCode)
        {
            //arrange            
            // Database with subject id: 1,2,3
            KretaContext context = MakeTestDatabaseWith3Data();

            SubjectService subjectService = new SubjectService(context);
            FieldsParameter fieldsParameter = new FieldsParameter();

            var controller = new SubjectController(mockLogger.Object, subjectService, mapper);

            // act
            if (context.Subjects != null)
            {
                EFSubject exptedtedSubject = context.Subjects.Where(subject => subject.Id.Equals(exptectedElementIid)).FirstOrDefault();
                if (exptedtedSubject != null)
                {
                    var actionResult = await controller.GetSubjectById(exptectedElementIid, fieldsParameter);

                    // assert
                    Assert.NotNull(actionResult);
                    Assert.IsType<BadRequestObjectResult>(actionResult);
                    var statusCodeReulst = (IStatusCodeActionResult)actionResult;
                    Assert.Equal(exptectedStatusCode, statusCodeReulst.StatusCode);

                    var objectResult = actionResult as BadRequestObjectResult;
                    Assert.NotNull(objectResult);
                    if (objectResult != null)
                    {
                        Assert.IsType<string>(objectResult.Value);
                    }
                }
            }
        }
    }
}

