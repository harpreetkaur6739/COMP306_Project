using _300910377_KAUR__300916412_YANG__Project.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _300910377_KAUR__300916412_YANG__Project.Services
{
    public class PatientEHRRecordService : IPatientEHRRecordService
    {
        private readonly PatientEHRContext _context;

        public PatientEHRRecordService(PatientEHRContext context)
        {
            _context = context;
        }

        public Task AddAsync(PatientEHR patientRecord)
        {
            //patientRecord.Id = Guid.NewGuid();
            _context.PatientEHR.Add(patientRecord);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<PatientEHR> patientRecords)
        {
            foreach (var patientRecord in patientRecords)
            {
                patientRecord.Id = Guid.NewGuid();
                _context.PatientEHR.Add(patientRecord);
            }
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task RemoveAsync(Guid id)
        {
            var patient = _context.PatientEHR.Find(id);
            if (patient == null)
            {
                return Task.CompletedTask;
            }
            _context.PatientEHR.Remove(patient);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<IEnumerable<PatientEHR>> GetAllAsync() => Task.FromResult<IEnumerable<PatientEHR>>(_context.PatientEHR.ToList());

        public Task<PatientEHR> FindAsync(Guid id)
        {
           var patient = _context.PatientEHR.Find(id);

            return Task.FromResult(patient);
        }

        public Task<IEnumerable<PatientEHR>> FindByPatientAsync(string patientId) {

            var patientRecords = _context.PatientEHR.Where(patient => patient.PatientId == patientId).ToList();

            return Task.FromResult<IEnumerable<PatientEHR>>(patientRecords);
        }

        public Task UpdateAsync(PatientEHR patientRecord)
        {
            try
            {
                _context.PatientEHR.Update(patientRecord);
                _context.SaveChanges();
            }
            catch (Exception e) {
                
            }

            return Task.CompletedTask;
        }
    }
}
