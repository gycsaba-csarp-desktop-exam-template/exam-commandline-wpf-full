using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using System.Collections;
using Newtonsoft.Json;
using ServiceKretaLogger;
using KretaWebApi.ActionFilters;
using Kreta.Models.DataModel;
using Kreta.Models.EFClass;
using Kreta.Models.Parameters;
using Kreta.Services;
using Kreta.Models.DataTranferObjects;



// TODO API
// Tesztek
// Biztonság
// Távoli elérés
// InMemeory database
// VUE összekapcsolás

/*
Kétféle útvonalválasztás létezik:

Konvenció alapú útválasztás és
Attribútum alapú útválasztás

A konvenció alapú útválasztást azért nevezik így, mert egy konvenciót hoz létre az URL-útvonalakra vonatkozóan.  Az első rész a vezérlő nevének, a második rész a műveleti módszernek, a harmadik rész pedig az opcionális paramétereknek a leképezését végzi. 

Az attribútumos útválasztás az attribútumokat használja, hogy az útvonalakat közvetlenül a vezérlőn belüli műveleti metódusokra képezze le. Általában az alap útvonalat a vezérlő osztály fölé helyezzük, ahogyan azt a Web API vezérlő osztályunkban is láthatjuk. Hasonlóképpen, az egyes műveleti metódusokhoz közvetlenül fölöttük hozzuk létre az útvonalaikat.
 */

//https://code-maze.com
//https://github.com/Arshu/ASP.NET-Core-In-Fly.io
//https://solrevdev.com/2020/05/18/deploy-aspnet-core-web-api-to-fly-via-docker.html

namespace KretaWebApi.Controllers
{
    //TODO: Docker
    // https://www.youtube.com/watch?v=3s-RfwvijpY&t=54s
    // https://referbruv.com/blog/dockerizing-a-simple-aspnet-core-application-for-release-build/
    // https://www.codeguru.com/dotnet/asp-net-docker/

    // https://mydbops.wordpress.com/2020/09/13/getting-started-with-dockerizing-mysql/
    // https://github.com/TonicAI/docker-testdb/tree/main/mysql
    // https://code-maze.com/mysql-aspnetcore-docker-compose/
    // https://github.com/binduchinnasamy/aspnetcore-mysql-docker

    //TODO: NoDatabase    

    // ToDo Best practice, secure
    // https://code-maze.com/aspnetcore-webapi-best-practices/
    // https://www.c-sharpcorner.com/UploadFile/1492b1/restful-day-2-inversion-of-control-using-dependency-injecti/

    [Route("[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ILoggerManager logger;
        private ISubjectService service;
        private IMapper mapper;

        public SubjectController(ILoggerManager logger, ISubjectService service, IMapper mapper)
        {
            logger.LogInfo($"Tantárgy vezérlő kérést kapott!");
            this.logger = logger;
            this.service = service;
            this.mapper = mapper;

            logger.LogInfo($"Szükséges objektumokat a controller megkapta!");
        }

        [HttpGet("api/subject", Name = "All subjects")]
        public async Task<IActionResult> GetAllSubjects([FromQuery] SubjectParameters subjectParameters)
        {

            logger.LogInfo($"Az összes tantárgy lekérdezése az adatbázisból");
            logger.LogInfo($"Paraméterek {subjectParameters}");
            var subjects = service.GetAllSubjects(subjectParameters);

            logger.LogInfo($"Kiolvasva {subjects.Count} tantárgy adat az adatbázisból");

            // pagination data in header
            var paginationMetadata = new
            {
                subjects.QueryString.NumberOfItem,
                subjects.QueryString.PageSize,
                subjects.QueryString.CurrentPage,
                subjects.QueryString.NumberOfPage,
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

            // nextId header data to insert new subject
            long nextId = 0;
            if (subjects != null && subjects.Count > 0)
                nextId = service.GetNextId();
            logger.LogInfo($"Meghatározva {nextId} a következő lehetséges id");
            Dictionary<string, string> nextIDToSerialize = new Dictionary<string, string>();
            nextIDToSerialize.Add("NextId", nextId.ToString());
            Response.Headers.Add("X-NextId", JsonConvert.SerializeObject(nextIDToSerialize));

            logger.LogInfo($"Visszatérés {subjects.Count} tantárgy adattal az adatbázisból");

            // ha nincs adat
            if ((subjects == null) || (subjects.Count == 0))
            {
                logger.LogInfo($"Paraméterek {subjectParameters}");
                return NoContent();
            }

            // ha van adat
            var subjectResult = mapper.Map<IEnumerable>(subjects);
            return Ok(subjectResult);

        }

        [HttpGet("api/subject-search-by-name", Name = "All subject search by name")]
        public async Task<IActionResult> SearchBySubjectName([FromQuery] SubjectNameSearchingParameters subjectNameSearchingParameters)
        {
            var subjects = service.SearchSubjectNameStartWith(subjectNameSearchingParameters.Name);
            logger.LogInfo($"Az összes tantárgy lekérdezése amelynek nevében szerepel '{subjectNameSearchingParameters.Name}' szó.");

            var subjectResult = mapper.Map<IEnumerable>(subjects);
            return Ok(subjectResult);

        }

        //https://stackoverflow.com/questions/57678813/net-core-api-purpose-of-producesresponsetype
        [HttpGet("api/subject/{id}", Name = "Subject by id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Subject))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateIDAttributeExists<EFSubject>))]
        public async Task<IActionResult> GetSubjectById(int id, [FromQuery] FieldsParameter fields)
        {
            EFSubject subject = null;
            try
            {
                subject = service.GetSubjectById(id);
            }
            catch (Exception exception)
            {
                logger.LogError($"GetSubjectById->{id} azonosítójú tantárgy nem található.");
                logger.LogError(exception.Message);
                return BadRequest($"No subject identified by {id} id.");
            }

            logger.LogInfo($"GetSubject(id)->{id}-jű tantárgy lekérése sikeres");
            Subject subjectResult = mapper.Map<Subject>(subject);
            return Ok(subjectResult);
 
        }

        [HttpPost("api/subject", Name = "Insert subject")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateSubject([FromBody] SubjectForCreationDto subjectForCreation)
        {
            logger.LogInfo("Új tantárgy felvétele az adatbázisba");
            logger.LogInfo("Új tantárgy azonosító:" + subjectForCreation.Id);
            logger.LogInfo("Új tantárgy neve:" + subjectForCreation.SubjectName);
            logger.LogInfo("Új tantárgy adatok rendben.");

            var insertedEFSubject = mapper.Map<EFSubject>(subjectForCreation);

            long count = service.GetNumberOfSubject();
            if (count>50)
            {
                return BadRequest("The number of subject in database are limited");
            }

            try
            {
                service.CreateSubject(insertedEFSubject);
            }
            catch (Exception exception)
            {
                logger.LogError($"CreateSubject->Hiba a {subjectForCreation.Id} azonosítójú tantárgy mentése során.");
                logger.LogError(exception.Message);
                return BadRequest("New subject can not save.");
            }

            var createdSubject = mapper.Map<Subject>(insertedEFSubject);

            logger.LogInfo($"CreateSubject->{createdSubject.Id} id-jü tantárgy felvétele az adatbászba: {createdSubject}");

            // return CreatedAtRoute(nameof(GetSubjectById), new {id = createdSubject.Id}, createdSubject);
            // https://stackoverflow.com/questions/39459348/asp-net-core-web-api-no-route-matches-the-supplied-values
            CreatedAtAction(nameof(GetSubjectById), new { id = createdSubject.Id }, createdSubject);
        }

        [HttpPut("api/subject/{id}", Name = "Update subject")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateIDAttributeExists<EFSubject>))]
        public async Task<IActionResult> UpdateSubject(long id, [FromBody] SubjectForUpdateDto subjectForUpdate)
        {
            logger.LogInfo("Tantárgy módosítása az adatbázisba");
            logger.LogInfo("Módosítandó tantárgy id-je:" + subjectForUpdate.Id);
            logger.LogInfo("Módosítandó tantárgy neve-je:" + subjectForUpdate.SubjectName);

            var updatedEFSubject = mapper.Map<EFSubject>(subjectForUpdate);
            try
            {
                service.Update(updatedEFSubject);
            }
            catch (Exception exception)
            {
                logger.LogError($"UpdateSubject->Hiba a {updatedEFSubject.Id} azonosítójú tantárgy frissítése során.");
                logger.LogError(exception.Message);
                return BadRequest("Subject can not save.");
            }

            var updatedSubject = mapper.Map<Subject>(updatedEFSubject);
            logger.LogInfo($"UpdateSubject->{updatedSubject.Id} id-jű tantárgy módosítva {updatedSubject}-re)");
            //return CreatedAtRoute(nameof(GetSubjectById), new { id = updatedSubject.Id }, updatedSubject);
            CreatedAtAction(nameof(GetSubjectById), new { id = updatedSubject.Id }, updatedSubject);
        }
        [HttpDelete("api/subject/{id}", Name = "Delete subject")]
        [ServiceFilter(typeof(ValidateIDAttributeExists<EFSubject>))]
        public async Task<IActionResult> DeleteSubject(long id)
        {
            try
            {
                var subject = service.GetSubjectById(id);
                service.DeleteSubject(subject);
            }
            catch (Exception exception)
            {
                logger.LogError($"DeleteSubject->Hiba a {id} azonosítójú tantárgy törlése során.");
                logger.LogError(exception.Message);
                return BadRequest("Subject can not delete.");
            }

            logger.LogInfo($"DeleteSubject->{id}-id-jű tantárgy törölve lett!");
            return NoContent();
        }
    }
}

