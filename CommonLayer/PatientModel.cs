using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class PatientModel
    {
        public int PatientId { get; set; }
        public string ProfilePic { get; set; }
        public string Concern { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string MedicalHiostory { get; set; }
        public bool IsTrash { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int UserId { get; set; }
    }
}
