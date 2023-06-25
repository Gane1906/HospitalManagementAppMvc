using CommonLayer;
using ManagerLayer.Interfaces;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class DoctorManager : IDoctorManager
    {
        private readonly IDoctorRepository doctorRepository;
        public DoctorManager(IDoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }
        public DoctorModel AddDoctorDetails(DoctorModel doctor)
        {
            try
            {
                return doctorRepository.AddDoctorDetails(doctor);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public DoctorModel GetDoctorById(int doctorId)
        {
            try
            {
                return doctorRepository.GetDoctorById(doctorId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public DoctorModel GetDoctorByUserId(int userId)
        {
            try
            {
                return doctorRepository.GetDoctorByUserId(userId);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public List<DoctorModel> GetAllDoctors()
        {
            try
            {
                return doctorRepository.GetAllDoctors();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
