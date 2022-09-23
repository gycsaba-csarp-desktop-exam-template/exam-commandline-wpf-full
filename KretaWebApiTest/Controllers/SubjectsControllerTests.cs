using AutoMapper;
using Kreta.Models.Context;
using Kreta.Repositories;
using Kreta.Repositories.Interfaces;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Parameters;
using KretaWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using ServiceKretaLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaWebApiTest.Controllers
{
    public class SubjectsControllerTests
    {
        private readonly SubjectController controller;

        private Mock<ILoggerManager> mockLogger;
        private MappingDataTest mappingData;

        public static DbContextOptions<KretaContext> contextOptions = new DbContextOptionsBuilder<KretaContext>()
            .UseInMemoryDatabase(databaseName: "KretaTest")
            .Options;

        private KretaContext context;
        private SubjectRepo subjectRepo;
        private RepositoryWrapper wrapper;

        public SubjectsControllerTests()
        {
            //KretaContext context = new KretaContext();

            mockLogger = new Mock<ILoggerManager>();
            mappingData= new MappingDataTest();

            context = new KretaContext(contextOptions);
            wrapper=new RepositoryWrapper(context);

        }

        // https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api

        [Fact]
        public void GetReturnSubjectSameId()
        {
            FieldsParameter fieldsParameter = new FieldsParameter();

            context = new KretaContext(contextOptions);
            var subjects = new List<EFSubject>
            {
                new EFSubject { Id = 1, SubjectName="Tesi" },
                new EFSubject { Id = 2, SubjectName="Tori" },
                new EFSubject { Id = 3, SubjectName="Angol" },
            };
            context.Subjects.AddRange(subjects);
            context.SaveChanges();


            var controller = new SubjectController(mockLogger.Object, wrapper, mappingData.MappingData().Object);


            var actionResult = controller.GetSubjectById(42, fieldsParameter);
            var objectResult = actionResult as OkObjectResult;
            Assert.NotNull(objectResult);
            var modelResult = objectResult.Value as Subject;            
            
            Assert.NotNull(modelResult);
            Assert.Equal(42, modelResult.Id);
        }
    }
}
