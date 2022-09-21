using AutoMapper;
using Kreta.Models.Context;
using Kreta.Repositories;
using Kreta.Repositories.Interfaces;
using KretaWebApi.Controllers;
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
        private readonly Mock<SubjectRepo> mock;
        private readonly SubjectController controller;
        private ILoggerManager logger;
        private IRepositoryWrapper repositoryWrapper;
        private MappingDataTest mappingData;

        public SubjectsControllerTests()
        {
            KretaContext context = new KretaContext();

            logger=new LoggerManager();
            repositoryWrapper = new RepositoryWrapper(context);
            mappingData= new MappingDataTest();

            mock = new Mock<SubjectRepo>();
            controller = new SubjectController(logger,repositoryWrapper, mappingData.MappingData().Object);
            
        }
    }
}
