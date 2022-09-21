using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KretaWebApiTest.Controllers
{
    public class MappingDataTest
    {
        public Mock<IMapper> MappingData()
        {
            var mappingService = new Mock<IMapper>();

            /*
            UserDetail im = getUserDetail(); // get value of UserDetails

            mappingService.Setup(m => m.Map<UserDetail, UserDetailViewModel>(It.IsAny<UserDetail>())).Returns(interview); // mapping data
            mappingService.Setup(m => m.Map<UserDetailViewModel, UserDetail>(It.IsAny<UserDetailtViewModel>())).Returns(im); // mapping data
            */
            return mappingService;
        }
    }
}
