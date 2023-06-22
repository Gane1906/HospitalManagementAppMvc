using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class DoctorModel
    {
        public int DoctorId { get; set; }
        public byte[] ProfilePic { get; set; }
        public string Qualification { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public bool IsTrash { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime ModifiedAt { get; set; }   
        public int UserId { get; set; }
    }
}
