using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using KretaWebApiContracts;
using Kreta.Repositories.Interfaces;
using AutoMapper;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using System.Collections;

namespace KretaWebApi.Controllers
{
    [Route("api/schoolclass")]
    [ApiController]
    public class SchoolClassController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper wrapper;
        private IMapper mapper;


        public SchoolClassController(ILoggerManager logger, IRepositoryWrapper wrapper, IMapper mapper)
        {
            this.logger = logger;
            this.wrapper = wrapper;
            this.mapper = mapper;
        }

        [HttpGet(Name ="All school classes")]
        public IActionResult GetData()
        {
            try
            {
                var schooClasses = wrapper.SchoolClass.GetAllSchoolClasses();
                logger.LogInfo("GetAllSchoolClass->Az összes osztály lekérdezése az adatbázisból.");
                var schoolClassResult = mapper.Map<IEnumerable>(schooClasses);
                return Ok(schoolClassResult);
            }
            catch (Exception ex)
            {
                logger.LogError("GetAllSchoolClass->Valami hiba történt az összes osztály lekédezése során.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name ="Scholl classes by id")]
        public IActionResult GetSchoolClassById(int id)
        {
            try
            {
                var schoolClass = wrapper.SchoolClass.GetSchoolClassById(id);
                if (schoolClass==null)
                {
                    logger.LogInfo($"GetSchoolClassById->Osztály id alapján: {id} idjű osztály nem létezik!");
                    return NotFound();
                }
                else
                {
                    logger.LogInfo($"GetSchoolClassById->Osztály id alapján: {id} idjű osztály lekérése sikeres!");
                    var schoolClassResult = mapper.Map<SchoolClassDto>(schoolClass);
                    return Ok(schoolClassResult);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami nem működik a GetSchoolClass(int id) metódusban:" + ex.Message);
                return StatusCode(500, "Internal server error");
            }

         }
    }
}
