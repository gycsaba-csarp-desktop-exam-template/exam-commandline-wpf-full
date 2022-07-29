using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using KretaWebApiContracts;
using Kreta.Repositories.Interfaces;
using AutoMapper;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using System.Collections;
using KretaParancssoriAlkalmazas.Models.EFClass;
using KretaParancssoriAlkalmazas.Models.DataModel;


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

    [Route("api/subject")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ILoggerManager logger;
        private IRepositoryWrapper repositoryWrapper;
        private IMapper mapper;

        public SubjectController(ILoggerManager logger, IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            this.logger = logger;
            this.repositoryWrapper = repositoryWrapper;
            this.mapper = mapper;
        }

        [HttpGet(Name = "All subjects")]
        public IActionResult GetAllSubjects()
        {
            try
            {
                var subjects = repositoryWrapper.SubjectRepo.GetAllSubjects();
                logger.LogInfo($"Az összes tantárgy lekérdezése az adatbázisból");

                var subjectResult = mapper.Map<IEnumerable>(subjects);
                return Ok(subjectResult);
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami nem működik a GetAllSubjects metódusban: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}", Name = "Subject by id")]
        public IActionResult GetSubjectById(int id)
        {
            try
            {
                var subject = repositoryWrapper.SubjectRepo.GetSubjectById(id);

                if (subject == null)
                {
                    logger.LogError($"GetSubjet(id)->Tantárgy id alapján: {id} -jű tantárgy nem létezik");
                    return NotFound();
                }
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

        [HttpPost]
        public IActionResult CreateSubject([FromBody] SubjectForCreationDto subjectForCreation)
        {
            try
            {
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

                var insertedEFSubject = mapper.Map<EFSubject>(subjectForCreation);

                repositoryWrapper.SubjectRepo.CreateSubject(insertedEFSubject);
                repositoryWrapper.Save();

                var createdSubject = mapper.Map<Subject>(insertedEFSubject);

                logger.LogInfo($"CreateSubject->{createdSubject.Id} id-jü tantárgy módosítva {createdSubject}-re");

                return NoContent();
            }
            catch (Exception ex)
            {
                logger.LogError($"Valami nem működik a CreateSubject metódusban:" + ex.Message);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSubject(long id, [FromBody] SubjectForUpdateDto subjectForUpdate)
        {
            try
            {


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
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSubject(long id)
        {
            try
            {
                var subject = repositoryWrapper.SubjectRepo.GetSubjectById(id);
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

