using _300910377_KAUR__300916412_YANG__Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _300910377_KAUR__300916412_YANG__Project.Services
{
    public interface IPatientEHRRecordService
    {
        Task<Guid> AddAsync(PatientEHR patientRecord);
        Task AddRangeAsync(IEnumerable<PatientEHR> patientRecords);
        Task RemoveAsync(Guid id);
        Task<IEnumerable<PatientEHR>> GetAllAsync();
        Task<PatientEHR> FindAsync(Guid id);
        Task<IEnumerable<PatientEHR>> FindByPatientAsync(string patientId);
        Task UpdateAsync(PatientEHR chapter);
    }
}
