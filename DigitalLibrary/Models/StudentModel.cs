using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Models
{
    public class StudentModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string BranchName { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public string PinCode { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Images { get; set; }
    }
}