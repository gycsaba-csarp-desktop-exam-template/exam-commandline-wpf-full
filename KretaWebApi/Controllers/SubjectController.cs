using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Kreta.Repositories.Interfaces;
using AutoMapper;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using System.Collections;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.DataModel;
using KretaParancssoriAlkalmazas.Models.Parameters;
using Newtonsoft.Json;
using System.Dynamic;
using System.ComponentModel.DataAnnotations;
using ServiceKretaLogger;


/*
Kétféle útvonalválasztás létezik:

Konvenció alapú útválasztás és
Attribútum alapú útválasztás

A konvenció alapú útválasztást azért nevezik így, mert egy konvenciót hoz létre az URL-útvonalakra vonatkozóan.  Az első rész a vezérlő nevének, a második rész a műveleti módszernek, a harmadik rész pedig az opcionális paramétereknek a leképezését végzi. 

Az attribútumos útválasztás az attribútumokat használja, hogy az útvonalakat közvetlenül a vezérlőn belüli műveleti metódusokra képezze le. Általában az alap útvonalat a vezérlő osztály fölé helyezzük, ahogyan azt a Web API vezérlő osztályunkban is láthatjuk. Hasonlóképpen, az egyes műveleti metódusokhoz közvetlenül fölöttük hozzuk létre az útvonalaikat.
 */

namespace KretaWebApi.Controllers
{
    //TODO: NoDatabase

    [Route("[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repositoryWrapper;
        private IMapper mapper;

        public SubjectController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            logger.LogInfo($"Tantárgy vezérlő kérést kapott!");
            this.logger = logger;
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
            logger.LogInfo($"Szükséges adatok elérhetőek!");
        }

        [HttpGet("api/subject",Name = "All subjects")]
        public IActionResult GetAllSubjects([FromQuery] SubjectParameters subjectParameters)
        {
            try
            {
                var subjects = repositoryWrapper.SubjectRepo.GetAllSubjects(subjectParameters);
                logger.LogInfo($"Az összes tantárgy lekérdezése az adatbázisból");

                var paginationMetadata = new
                {
                    subjects.TotalCount,
                    subjects.PageSize,
                    subjects.CurrentPage,
                    subjects.TotalPages,
                    subjects.HasNext,
                    subjects.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(paginationMetadata));

                long nextId = 0;
                if (subjects.Count>0)
                    nextId = repositoryWrapper.SubjectRepo.GetNextId();
                Dictionary<string,string> nextIDToSerialize=new Dictionary<string,string>();
                nextIDToSerialize.Add("NextId", nextId.ToString());

                Response.Headers.Add("X-NextId", JsonConvert.SerializeObject(nextIDToSerialize));

                logger.LogInfo($"Visszatérés {subjects.Count} tantárgy adattal az adatbázisból");

                var subjectResult = mapper.Map<IEnumerable>(subjects);
                return Ok(subjectResult);
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami nem működik a GetAllSubjects metódusban: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("api/subject-search-by-name", Name = "All subject search by name")]
        public IActionResult SearchBySubjectName([FromQuery] SubjectNameSearchingParameters subjectNameSearchingParameters)
        {
            try
            {
                var subjects = repositoryWrapper.SubjectRepo.SearchBySubjectName(subjectNameSearchingParameters);
                logger.LogInfo($"Az összes tantárgy lekérdezése amelynek nevében szerepel '{subjectNameSearchingParameters.Name}' szó.");

                var subjectResult = mapper.Map<IEnumerable>(subjects);
                return Ok(subjectResult);

            }
            catch (Exception ex)
            {
                logger.LogError($"Valami nem működik a GetAllSubjectSearchByName metódusban: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("api/subject/{id}", Name = "Subject by id")]
        public IActionResult GetSubjectById(int id, [FromQuery] FieldsParameter fields)
        {
            //TODO: Nem működik, FieldsParameter nulla lesz. URI hiba?

            try
            {
                var subject = repositoryWrapper.SubjectRepo.GetSubjectById(id,fields.Fields);

                if (subject==default(ExpandoObject))
                {
                    logger.LogError($"{id}-jú tantárgy nem létezik");
                    return NotFound();
                }

                /*if (subject == null)
                {
                    logger.LogError($"GetSubjet(id)->Tantárgy id alapján: {id} -jű tantárgy nem létezik");
                    return NotFound();
                }*/
                else
                {
                    logger.LogInfo($"GetSubject(id)->{id}-jű tantárgy lekérése sikeres");
                    var subjectResult = mapper.Map<Subject>(subject);
                    return Ok(subjectResult);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami nem működik a GetSubject(int id) metódusban:" + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("api/subject",Name ="Insert subject")]
        public IActionResult CreateSubject([FromBody] SubjectForCreationDto subjectForCreation)
        {
            try
            {
                logger.LogInfo("Új tantárgy felvétele az adatbázisba");
                logger.LogInfo("Új tantárgy azonosító:" + subjectForCreation.Id);
                logger.LogInfo("Új tantárgy neve:" + subjectForCreation.SubjectName);

                if (subjectForCreation == null)
                {
                    logger.LogError("CreateSubject->Tantárgy létrehozás során a klienstől küldött tantárgy null.");
                    return BadRequest("Subject is null");
                }
                if (!ModelState.IsValid)
                {
                    logger.LogInfo("CreateSubject->Tantárgy létrehozás során a klienstől küldött tantárgy nem elfogadható.");
                    return BadRequest("Invalid model object!");
                }

                logger.LogInfo("Új tantárgy adatok rendben.");

                var insertedEFSubject = mapper.Map<EFSubject>(subjectForCreation);

                repositoryWrapper.SubjectRepo.CreateSubject(insertedEFSubject);
                repositoryWrapper.Save();

                var createdSubject = mapper.Map<Subject>(insertedEFSubject);

                logger.LogInfo($"CreateSubject->{createdSubject.Id} id-jü tantárgy felvétele az adatbászba: {createdSubject}");

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami nem működik a CreateSubject metódusban:" + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("api/subject/{id}", Name ="Update subject")]
        public IActionResult UpdateSubject(long id, [FromBody] SubjectForUpdateDto subjectForUpdate)
        {
            try
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

                repositoryWrapper.SubjectRepo.Update(updatedEFSubject);
                repositoryWrapper.Save();

                var updatedSubject = mapper.Map<Subject>(updatedEFSubject);

                logger.LogInfo($"UpdateSubject->{updatedSubject.Id} id-jű tantárgy módosítva {updatedSubject}-re)");

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"UpdateSubject->Valami nem sikerült a metóduson belül: {ex.Message}");
                //return StatusCode(500, "Internal server error");
                return Ok(ex.Message);
            }
        }
        [HttpDelete("api/subject/{id}", Name ="Delete subject")]
        public IActionResult DeleteSubject(long id)
        {
            try
            {
                var subject =  repositoryWrapper.SubjectRepo.GetSubjectById(id);
                if (subject == null)
                {
                    logger.LogError($"DeleteSubject->A törlendő tantárgy {id} id-vel nem található az adatbázisban.");
                    return NotFound();
                }

                repositoryWrapper.SubjectRepo.DeleteSubject(subject);
                repositoryWrapper.Save();

                logger.LogInfo($"DeleteSubject->{id}-id-jű tantárgy törölve lett!");

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"DeleteSubject->Valami nem sikerült a metóduson belül: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }




    }
}

