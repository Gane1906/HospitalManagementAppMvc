using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface IPatientManager
    {
        public PatientModel AddPatientDetails(PatientModel patient);
        public PatientModel GetPatientbyId(int patientId);
        public PatientModel GetPatientByUserId(int userId);
        public List<PatientModel> GetAllPatients();
    }
}
