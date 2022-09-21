using AutoMapper;
using Kreta.Models.Context;
using Kreta.Repositories;
using Kreta.Repositories.Interfaces;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.Parameters;
using KretaWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
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

        public SubjectsControllerTests()
        {
            //KretaContext context = new KretaContext();

            mockLogger = new Mock<ILoggerManager>();
            mappingData= new MappingDataTest();

                                    
        }

        // https://learn.microsoft.com/en-us/aspnet/web-api/overview/testing-and-debugging/unit-testing-controllers-in-web-api

        [Fact]
        public GetReturnSubjectSameId()
        {
            var mockRepository = new Mock<IRepositoryWrapper>();


            mockRepository.Setup(x => x.SubjectRepo.GetSubjectById(42)).Returns(new EFSubject(42, "Történelem"));
            var controller = new SubjectController(mockLogger.Object, mockRepository.Object, mappingData.MappingData().Object);
            FieldsParameter fieldsParameter = new FieldsParameter();

            var actionResult = controller.GetSubjectById(42, fieldsParameter);
            var contentResult = actionResult as OkObjectResult<EFSubject>;
            
            Assert.NotNull(result);
            Assert.NotNull(result.Content);
            Assert.NotNull(42, result.Content.Id);


        }
    }
}
