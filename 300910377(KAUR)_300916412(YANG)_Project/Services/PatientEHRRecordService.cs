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
        //private readonly ConcurrentDictionary<Guid, PatientEHR> _patientRecords = new ConcurrentDictionary<Guid, PatientEHR>();

        private readonly PatientEHRContext _context;

        public PatientEHRRecordService(PatientEHRContext context)
        {
            _context = context;
        }

        public Task AddAsync(PatientEHR patientRecord)
        {
            patientRecord.Id = Guid.NewGuid();
            _context.PatientEHR.Add(patientRecord);
            _context.SaveChanges();
            /*patientRecord.Id = Guid.NewGuid();
            _patientRecords[patientRecord.Id] = patientRecord;*/
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
            //_patientRecords.TryRemove(id, out PatientEHR removed);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<PatientEHR>> GetAllAsync() => Task.FromResult<IEnumerable<PatientEHR>>(_context.PatientEHR.ToList());

        public Task<PatientEHR> FindAsync(Guid id)
        {
           var patient = _context.PatientEHR.Find(id);
            //_patientRecords.TryGetValue(id, out PatientEHR patientRecord);
            return Task.FromResult(patient);
        }

        public Task UpdateAsync(PatientEHR patientRecord)
        {
            
            _context.PatientEHR.Update(patientRecord);
            _context.SaveChanges();
           // _patientRecords[patientRecord.Id] = patientRecord;
            return Task.CompletedTask;
        }
    }
}
