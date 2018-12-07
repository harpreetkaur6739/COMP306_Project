using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _300910377_KAUR__300916412_YANG__Project.Models;
using _300910377_KAUR__300916412_YANG__Project.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _300910377_KAUR__300916412_YANG__Project.Controllers
{
    [Route("api/[controller]")]
    public class PatientEHRController : ControllerBase
    {
        private readonly IPatientEHRRecordService _patientEHRRecordService;

        public PatientEHRController(IPatientEHRRecordService patientEHRRecordService)
        {
            _patientEHRRecordService = patientEHRRecordService;

        }

        // GET: api/<controller>
        [HttpGet()]
        [Route("allRecords")]
        [ProducesResponseType(typeof(IEnumerable<PatientEHR>), 200)]
        public Task<IEnumerable<PatientEHR>> GetPatientEHRAsync() => _patientEHRRecordService.GetAllAsync();

        // GET api/<controller>/5
        [HttpGet("{id}", Name = nameof(GetPatientEHRByIdAsync))]
        [ProducesResponseType(typeof(PatientEHR), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetPatientEHRByIdAsync(Guid id)
        {
            PatientEHR patient = await _patientEHRRecordService.FindAsync(id);
            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(patient);
            }
        }

        [HttpGet("patient/{id}", Name = nameof(GetPatientEHRByPatientIdAsync))]
        [ProducesResponseType(typeof(IEnumerable<PatientEHR>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetPatientEHRByPatientIdAsync(string id)
        {
            IEnumerable<PatientEHR> patientRecords = await _patientEHRRecordService.FindByPatientAsync(id);
            if (patientRecords == null)
            {
                return NotFound();
            }
            else
            {
                return new ObjectResult(patientRecords);
            }
        }



        [HttpPost]
        [ProducesResponseType(typeof(PatientEHR), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostPatientEHRAsync([FromBody]PatientEHR patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            try
            {
                Guid id = await _patientEHRRecordService.AddAsync(patient);
                
            }
            catch (Exception ex) {
                Console.Write(ex.StackTrace);
            }
            return CreatedAtRoute(nameof(GetPatientEHRByIdAsync),
                   new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> PutPatientEHRAsync(Guid id, [FromBody]PatientEHR patient)
        {
            if (patient == null || id != patient.Id)
            {
                return BadRequest();
            }

            PatientEHR pt = await _patientEHRRecordService.FindAsync(id);
            if (pt == null)
            {
                return NotFound();
            }

            pt.ReasonForVisit = patient.ReasonForVisit;
            pt.VisitDateTime = patient.VisitDateTime;
            pt.DiagnosisCode = patient.DiagnosisCode;
            pt.DiagnosisDescription = patient.DiagnosisDescription;
            pt.LabName = patient.LabName;
            pt.LabValue = patient.LabValue;
            pt.LabUnits = patient.LabUnits;
            pt.LabDateTime = patient.LabDateTime;
            
            await _patientEHRRecordService.UpdateAsync(pt);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id) => await _patientEHRRecordService.RemoveAsync(id);
    }
}
