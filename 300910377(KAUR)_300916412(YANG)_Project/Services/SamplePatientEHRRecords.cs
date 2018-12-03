using _300910377_KAUR__300916412_YANG__Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _300910377_KAUR__300916412_YANG__Project.Services
{
    public class SamplePatientEHRRecords
    {
        private readonly IPatientEHRRecordService _PatientEHRRecordService;
        private readonly PatientEHRContext _context;

        public SamplePatientEHRRecords(IPatientEHRRecordService patientEHRRecordService, PatientEHRContext context)
        {
            _PatientEHRRecordService = patientEHRRecordService;

            _context = context;
        }

        public async Task CreatePatientsAsync()
        {
            await _PatientEHRRecordService.AddRangeAsync(_context.PatientEHR.ToList());
        }
    }
}
