using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using KretaWebApiContracts;
using Kreta.Repositories.Interfaces;
using AutoMapper;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using System.Collections;
using KretaParancssoriAlkalmazas.Models.Parameters;
using System.Dynamic;
using KretaParancssoriAlkalmazas.Models.DataModel;

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
        public IActionResult GetAllSchoolClasses()
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
        
        [HttpGet("api/schoolclass-paged",Name="All paged school classes")]
        public IActionResult GetAllPagedSchoolClasses([FromQuery] SchollClassPageParameters schoolClassPageParameters)
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

        [HttpGet("api/schoolclass-filtering",Name ="Filtering school classes")]
        public IActionResult GetAllFilteringSchoolClasses([FromQuery] SchoolClassQueryYearParameter schoolClassQueryYearParameter)
        {
            try
            {
                if (!schoolClassQueryYearParameter.ValidYearRange)
                {
                    return BadRequest("A befejező év nem lehet kisebb a kezdő évnél, a kezdő év nagyobb egyenlő kell legyen 9-el, a befejező év kisebb egyenlő kell legyen 12-nél");
                }

                var schoolClasses = wrapper.SchoolClass.GetAllFilteringSchoolClass(schoolClassQueryYearParameter);

                logger.LogInfo("GetAllFilteringSchoolClasses->Az összes osztály szürt lekérdezése az adatbázisból.");
                logger.LogInfo($"GetAllFilteringSchoolClasses->Szürési feltétel: {schoolClassQueryYearParameter.MinYear}<=ev<={schoolClassQueryYearParameter.MaxYear} ");

                var schoolClassResult = mapper.Map<IEnumerable>(schoolClasses);
                return Ok(schoolClassResult);
            }
            catch (Exception ex)
            {
                logger.LogError("GetAllFilteringSchoolClass->Valami hiba történt az összes osztály szürt lekédezése során.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("api/schoolclass-sorted", Name = "Sorted chool classes")]
        public IActionResult GetSchoolClassSorted([FromQuery] SchoolClassSortingParameters schoolClassSortingParameters)
        {
            try
            {
                var schoolClasses = wrapper.SchoolClass.GetAllSorted(schoolClassSortingParameters);

                logger.LogInfo("GetSchoolClassSorted->Az összes osztály rendezett lekérdezése az adatbázisból.");
                logger.LogInfo($"GetSchoolClassSorted->rendezési feltétel: {schoolClassSortingParameters.OrderBy} ");

                var schoolClassResult = mapper.Map<IEnumerable>(schoolClasses);
                return Ok(schoolClassResult);

            }
            catch (Exception ex)
            {
                logger.LogError("GetSchoolClassSorted->Valami hiba történt az összes osztály szürt lekédezése során.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("api/schoolclass-select", Name = "All school classes and select filds")]
        public IActionResult GetAllSchoolClasses([FromQuery] SchoolClassFieldsParameters fields)
        {
            try
            {
                var schooClasses = wrapper.SchoolClass.GetAllSelectField(fields);
                logger.LogInfo("GetAllSchoolClass->Az összes osztály lekérdezése az adatbázisból mező selekcióval.");
                var schoolClassResult = mapper.Map<IEnumerable>(schooClasses);
                return Ok(schoolClassResult);
            }
            catch (Exception ex)
            {
                logger.LogError("GetAllSchoolClass->Valami hiba történt az összes osztály lekédezése során.");
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
                    var schoolClassResult = mapper.Map<SchoolClass>(schoolClass);
                    return Ok(schoolClassResult);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami nem működik a GetSchoolClass(int id) metódusban:" + ex.Message);
                return StatusCode(500, "Internal server error");
            }

        }


        [HttpGet("api/schoolclass-select/{id}", Name = "Scholl classes by id and select")]
        public IActionResult GetSchoolClassByIdAndSelect(int id, [FromQuery] SchoolClassFieldsParameters fields)
        {
            try
            {
                //var schoolClasses = wrapper.SchoolClass.GetSchoolClassById(id);
                var schoolClass = wrapper.SchoolClass.GetSchoolClassById(id, fields);

                if (schoolClass == default(ExpandoObject))
                {
                    logger.LogInfo($"GetSchoolClassById->Osztály id alapján: {id} idjű osztály nem létezik!");
                    return NotFound();
                }
                /*
                if (schoolClass == null)
                {
                    logger.LogInfo($"GetSchoolClassById->Osztály id alapján: {id} idjű osztály nem létezik!");
                    return NotFound();
                }*/
                else
                {
                    logger.LogInfo($"GetSchoolClassById->Osztály id alapján: {id} idjű osztály lekérése sikeres!");
                    var schoolClassResult = mapper.Map<SchoolClass>(schoolClass);
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