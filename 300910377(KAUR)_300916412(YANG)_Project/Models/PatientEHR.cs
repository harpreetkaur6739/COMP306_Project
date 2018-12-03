using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _300910377_KAUR__300916412_YANG__Project.Models
{
    public class PatientEHR
    {
        public Guid Id { get; set; }

        public string PatientId { get; set; }

        public string PatientDob { get; set; }

        public string PatientGender { get; set; }

        public string PatientMaritalStatus { get; set; }

        public string PatientCity { get; set; }

        public string PatientCountry { get; set; }    

        public string VisitDateTime { get; set; }
        
        public string ReasonForVisit { get; set; }

        public string DiagnosisCode { get; set; }

        public string DiagnosisDescription { get; set; }

        public string LabName { get; set; }

        public string LabDateTime { get; set; }

        public string LabValue { get; set; }

        public string LabUnits { get; set; }
    }
}
