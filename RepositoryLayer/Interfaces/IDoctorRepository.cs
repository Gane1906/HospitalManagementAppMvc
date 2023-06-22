using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IDoctorRepository
    {
        public DoctorModel AddDoctorDetails(DoctorModel doctor);
        public DoctorModel GetDoctorById(int doctorId);
        public DoctorModel GetDoctorByUserId(int userId);
    }
}
