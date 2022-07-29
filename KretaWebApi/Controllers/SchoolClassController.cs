using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using KretaWebApiContracts;
using Kreta.Repositories.Interfaces;
using AutoMapper;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using System.Collections;
using KretaParancssoriAlkalmazas.Models.Parameters;

namespace KretaWebApi.Controllers
{
    [Route("[controller]")]
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

        [HttpGet("api/schoolclass",Name = "All school classes")]
        public IActionResult GetAllSchoolClass()
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
        
        [HttpGet("api/schoolclasspaged",Name="All paged school classes")]
        public IActionResult GetAllPagedSchoolClass([FromQuery] SchollClassPageParameters schoolClassPageParameters)
        {
            try
            {
                var schoolClasses = wrapper.SchoolClass.GetAllPagedSchoolClasses(schoolClassPageParameters);
  

                var metadata = new
                {
                    schoolClasses.TotalCount,
                    schoolClasses.PageSize,
                    schoolClasses.CurrentPage,
                    schoolClasses.TotalPages,
                    schoolClasses.HasNext,
                    schoolClasses.HasPrevious
                };

                Response.Headers.Add("X-Pagination", Newtonsoft.Json.JsonConvert.SerializeObject(metadata));

                logger.LogInfo("GetAllPagedSchoolClass->Az összes osztály lapozott lekérdezése az adatbázisból.");
                logger.LogInfo($"GetAllPagedSchoolClass->{schoolClasses.TotalCount} adat lekérdezése az adatbázisból.");

                var schoolClassResult = mapper.Map<IEnumerable>(schoolClasses);
                return Ok(schoolClassResult);
            }
            catch (Exception ex)
            {
                logger.LogError("GetAllPagedSchoolClass->Valami hiba történt az összes osztály lekédezése során.");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet("api/schoolclass/{id}", Name = "Scholl classes by id")]
        public IActionResult GetSchoolClassById(int id)
        {
            try
            {
                var schoolClass = wrapper.SchoolClass.GetSchoolClassById(id);
                if (schoolClass == null)
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