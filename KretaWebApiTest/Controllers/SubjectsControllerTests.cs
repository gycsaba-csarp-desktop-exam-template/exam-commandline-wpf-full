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

namespace KretaWebApiTest.Controllers
{
    public class SubjectsControllerTests
    {
        private readonly SubjectController controller;

        private Mock<ILoggerManager> mockLogger;
        //private Mock<IMapper> mockMapper;
        private IMapper mapper;

        public static DbContextOptions<KretaContext> contextOptions = new DbContextOptionsBuilder<KretaContext>()
            .UseInMemoryDatabase(databaseName: "KretaTest")
            .Options;

        //private KretaContext context;
        //private SubjectRepo subjectRepo;
        //private RepositoryWrapper wrapper;

        public SubjectsControllerTests()
        {
            //KretaContext context = new KretaContext();

            mockLogger = new Mock<ILoggerManager>();
            // https://stackoverflow.com/questions/36074324/how-to-mock-an-automapper-imapper-object-in-web-api-tests-with-structuremap-depe
            //https://www.thecodebuzz.com/unit-test-mock-automapper-asp-net-core-imapper/
            //mockMapper = new Mock<IMapper>();
            //mockMapper.Setup(x => x.Map<Subject>(It.IsAny<Subject>()))
            //    .Returns(It.IsAny<Subject>());
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
          
        

        // https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api

        [Fact]
        public void GetReturnSubjectSameId()
        {
            FieldsParameter fieldsParameter = new FieldsParameter();

            KretaContext context = new KretaContext(contextOptions);
            var subjectTableData = new List<EFSubject>
            {
                new EFSubject { Id = 1, SubjectName="Tesi" },
                new EFSubject { Id = 2, SubjectName="Tori" },
                new EFSubject { Id = 3, SubjectName="Angol" },
            };
            context.Subjects.AddRange(subjectTableData);
            context.SaveChanges();
            //RepositoryWrapper wrapper = new RepositoryWrapper(context);
            SubjectService subjectService=new SubjectService(context);
            

            //arrange
            int exptectedTestedElementInTableId = 1;
            EFSubject exptedtedSubject = subjectTableData.Where(subject => subject.Id.Equals(exptectedTestedElementInTableId)).FirstOrDefault();
            var controller = new SubjectController(mockLogger.Object, subjectService, mapper);

            // act
            var actionResult = controller.GetSubjectById(exptectedTestedElementInTableId, fieldsParameter);
            
            // assert
            Assert.NotNull(actionResult);
            var objectResult = actionResult as OkObjectResult;
            Assert.NotNull(objectResult);
            var modelResult = objectResult.Value as Subject;            
            
            Assert.NotNull(modelResult);
            Assert.Equal(exptedtedSubject.Id, modelResult.Id);
            Assert.Equal(exptedtedSubject.SubjectName, modelResult.SubjectName);
        }
    }
}
