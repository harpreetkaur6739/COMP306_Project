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

        [HttpPost]
        [ProducesResponseType(typeof(PatientEHR), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostPatientEHRAsync([FromBody]PatientEHR patient)
        {
            if (patient == null)
            {
                return BadRequest();
            }
            await _patientEHRRecordService.AddAsync(patient);
            return CreatedAtRoute(nameof(GetPatientEHRByIdAsync),
              new { id = patient.Id }, patient);
        }

        // PUT api/bookchapters/guid
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
            if (await _patientEHRRecordService.FindAsync(id) == null)
            {
                return NotFound();
            }
            await _patientEHRRecordService.UpdateAsync(patient);
            return new NoContentResult();
        }

        // DELETE api/bookchapters/guid
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id) => await _patientEHRRecordService.RemoveAsync(id);
    }
}
