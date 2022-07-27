using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using KretaWebApiContracts;
using Kreta.Repositories.Interfaces;
using AutoMapper;
using KretaParancssoriAlkalmazas.Models.DataTranferObjects;
using System.Collections;
using Kreta.Models;


/*
Kétféle útvonalválasztás létezik:

Konvenció alapú útválasztás és
Attribútum alapú útválasztás

A konvenció alapú útválasztást azért nevezik így, mert egy konvenciót hoz létre az URL-útvonalakra vonatkozóan.  Az első rész a vezérlő nevének, a második rész a műveleti módszernek, a harmadik rész pedig az opcionális paramétereknek a leképezését végzi. 

Az attribútumos útválasztás az attribútumokat használja, hogy az útvonalakat közvetlenül a vezérlőn belüli műveleti metódusokra képezze le. Általában az alap útvonalat a vezérlő osztály fölé helyezzük, ahogyan azt a Web API vezérlő osztályunkban is láthatjuk. Hasonlóképpen, az egyes műveleti metódusokhoz közvetlenül fölöttük hozzuk létre az útvonalaikat.
 */

namespace KretaWebApi.Controllers
{
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

        [HttpGet(Name ="All subjects")]
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

        [HttpGet("{id}",Name ="Subject by id")]
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
                    var subjectResult = mapper.Map<SubjectDto>(subject);
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
            if (subjectForCreation == null)
            {
                logger.LogError("CreateSubject->Subject sent to creation from client is null");
                return BadRequest("Subject is null");
            }
            if (!ModelState.IsValid)
            {
                logger.LogInfo("CreateSubject->Subject sent to creation from clien is not valid.");
                return BadRequest("Invalid model object!");
            }

            var subjectEntity = mapper.Map<Subject>(subjectForCreation);

            repositoryWrapper.SubjectRepo.CreateSubject(subjectEntity);
            repositoryWrapper.Save();

            var createdSubject = mapper.Map<SubjectDto>(subjectEntity);

            return CreatedAtRoute("SubjectById", new { id = createdSubject.Id }, createdSubject);
        }
    }         
}
