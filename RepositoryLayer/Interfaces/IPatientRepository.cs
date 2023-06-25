using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IPatientRepository
    {
        public PatientModel AddPatientDetails(PatientModel patient);
        public PatientModel GetPatientbyId(int patientId);
        public PatientModel GetPatientByUserId(int userId);
        public List<PatientModel> GetAllPatients();
    }
}
