using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using System.Collections;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Parameters;
using Newtonsoft.Json;
using ServiceKretaLogger;
using KretaParancssoriAlkalmazas.Services;



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
        public IActionResult GetAllSubjects([FromQuery] SubjectParameters subjectParameters)
        {

            logger.LogInfo($"Az összes tantárgy lekérdezése az adatbázisból");
            logger.LogInfo($"Paraméterek {subjectParameters}");

            var subjects = service.GetAllSubjects(subjectParameters);
            throw new AccessViolationException("Violation Exception while accessing the resource.");

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
        public IActionResult SearchBySubjectName([FromQuery] SubjectNameSearchingParameters subjectNameSearchingParameters)
        {
            var subjects = service.SearchSubjectNameStartWith(subjectNameSearchingParameters.Name);
            logger.LogInfo($"Az összes tantárgy lekérdezése amelynek nevében szerepel '{subjectNameSearchingParameters.Name}' szó.");

            var subjectResult = mapper.Map<IEnumerable>(subjects);
            return Ok(subjectResult);

        }

        [HttpGet("api/subject/{id}", Name = "Subject by id")]
        public IActionResult GetSubjectById(int id, [FromQuery] FieldsParameter fields)
        {
            //TODO: Nem működik, FieldsParameter nulla lesz. URI hiba?

            // fields visszaállítás, a tesztbe ExpandoObjectel nem megy meg
            //var subject = repositoryWrapper.SubjectRepo.GetSubjectById(id,fields.Fields);
            var subject = service.GetSubjectById(id);
            /*if (subject==default(ExpandoObject))
            {
                logger.LogError($"{id}-jú tantárgy nem létezik");
                return NotFound();
            }*/

            if (subject == null)
            {
                logger.LogError($"GetSubjet(id)->Tantárgy id alapján: {id} -jű tantárgy nem létezik");
                return NotFound();
            }
            else
            {
                logger.LogInfo($"GetSubject(id)->{id}-jű tantárgy lekérése sikeres");
                Subject subjectResult = mapper.Map<Subject>(subject);
                return Ok(subjectResult);
            }

        }

        [HttpPost("api/subject", Name = "Insert subject")]
        public IActionResult CreateSubject([FromBody] SubjectForCreationDto subjectForCreation)
        {
            logger.LogInfo("Új tantárgy felvétele az adatbázisba");
            logger.LogInfo("Új tantárgy azonosító:" + subjectForCreation.Id);
            logger.LogInfo("Új tantárgy neve:" + subjectForCreation.SubjectName);

            if (subjectForCreation == null)
            {
                logger.LogError("CreateSubject->Tantárgy létrehozás során a klienstől küldött tantárgy null.");
                return BadRequest("Subject is null");
            }
            logger.LogInfo("Új tantárgy adatok rendben.");

            var insertedEFSubject = mapper.Map<EFSubject>(subjectForCreation);

            if (!ModelState.IsValid)
            {
                logger.LogInfo("CreateSubject->Tantárgy létrehozás során a klienstől küldött tantárgy nem elfogadható.");
                return BadRequest("Invalid model object!");
            }

            service.CreateSubject(insertedEFSubject);

            var createdSubject = mapper.Map<Subject>(insertedEFSubject);

            logger.LogInfo($"CreateSubject->{createdSubject.Id} id-jü tantárgy felvétele az adatbászba: {createdSubject}");

            return NoContent();
        }

        [HttpPut("api/subject/{id}", Name = "Update subject")]
        public IActionResult UpdateSubject(long id, [FromBody] SubjectForUpdateDto subjectForUpdate)
        {
            logger.LogInfo("Tantárgy módosítása az adatbázisba");
            logger.LogInfo("Módosítandó tantárgy id-je:" + subjectForUpdate.Id);
            logger.LogInfo("Módosítandó tantárgy neve-je:" + subjectForUpdate.SubjectName);


            if (subjectForUpdate == null)
            {
                logger.LogError("UpdateSubject->Tantárgy módosítás során a klienstől küldött tantárgy null.");
                return BadRequest("Subject is null");
            }
            if (!ModelState.IsValid)
            {
                logger.LogInfo("UpdateSubject->Tantárgy módosítás során a klienstől küldött tantárgy nem elfogadható.");
            }

            var updatedEFSubject = mapper.Map<EFSubject>(subjectForUpdate);
            service.Update(updatedEFSubject);

            var updatedSubject = mapper.Map<Subject>(updatedEFSubject);
            logger.LogInfo($"UpdateSubject->{updatedSubject.Id} id-jű tantárgy módosítva {updatedSubject}-re)");
            return NoContent();
        }
        [HttpDelete("api/subject/{id}", Name = "Delete subject")]
        public IActionResult DeleteSubject(long id)
        {
            var subject = service.GetSubjectById(id);
            if (subject == null)
            {
                logger.LogError($"DeleteSubject->A törlendő tantárgy {id} id-vel nem található az adatbázisban.");
                return NotFound();
            }
            service.DeleteSubject(subject);
            logger.LogInfo($"DeleteSubject->{id}-id-jű tantárgy törölve lett!");
            return NoContent();
        }
    }
}

