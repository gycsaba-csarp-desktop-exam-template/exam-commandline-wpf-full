﻿using Microsoft.AspNetCore.Http;
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
using KretaParancssoriAlkalmazas.Models.Helpers;


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
            logger.LogInfo($"Szükséges objektumokat a controller megkapta!");
        }

        [HttpGet("api/subject",Name = "All subjects")]
        public IActionResult GetAllSubjects([FromQuery] SubjectParameters subjectParameters)
        {
            try
            {
                logger.LogInfo($"Az összes tantárgy lekérdezése az adatbázisból");
                logger.LogInfo($"Paraméterek {subjectParameters}");

                var subjects = repositoryWrapper.SubjectRepo.GetAllSubjects(subjectParameters);
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
                if (subjects!=null && subjects.Count>0)
                    nextId = repositoryWrapper.SubjectRepo.GetNextId();
                logger.LogInfo($"Meghatározva {nextId} a következő lehetséges id");
                Dictionary<string,string> nextIDToSerialize=new Dictionary<string,string>();
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
                var subjects = repositoryWrapper.SubjectRepo.SearchSubjectNameStartWith(subjectNameSearchingParameters.Name);
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
                // fields visszaállítás, a tesztbe ExpandoObjectel nem megy meg
                //var subject = repositoryWrapper.SubjectRepo.GetSubjectById(id,fields.Fields);
                var subject = repositoryWrapper.SubjectRepo.GetSubjectById(id);
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
                    //Subject subjectResult = mapper.Map<Subject>(subject);
                    EFSubject subjectResult = subject;
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
                logger.LogInfo("Új tantárgy adatok rendben.");

                var insertedEFSubject = mapper.Map<EFSubject>(subjectForCreation);

                if (!ModelState.IsValid)
                {
                    logger.LogInfo("CreateSubject->Tantárgy létrehozás során a klienstől küldött tantárgy nem elfogadható.");
                    return BadRequest("Invalid model object!");
                }

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

