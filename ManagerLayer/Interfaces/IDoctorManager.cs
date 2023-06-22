using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interfaces
{
    public interface IDoctorManager
    {
        public DoctorModel AddDoctorDetails(DoctorModel doctor);
        public DoctorModel GetDoctorById(int doctorId);
        public DoctorModel GetDoctorByUserId(int userId);
    }
}
