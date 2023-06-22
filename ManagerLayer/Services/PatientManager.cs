using CommonLayer;
using ManagerLayer.Interfaces;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ManagerLayer.Services
{
    public class PatientManager : IPatientManager
    {
        private readonly IPatientRepository patientRepository;
        public PatientManager(IPatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        public PatientModel AddPatientDetails(PatientModel patient)
        {
            try
            {
                return patientRepository.AddPatientDetails(patient);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public PatientModel GetPatientbyId(int patientId)
        {
            try
            {
                return patientRepository.GetPatientbyId(patientId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
