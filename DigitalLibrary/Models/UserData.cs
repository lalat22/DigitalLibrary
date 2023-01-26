using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Models
{
    public class UserData
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int StatusTypeId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public  int UpadatedBy { get; set; }
        public string Email { get; set; }

        public class UserLogs
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool IsAdmin { get; set; }
        }

    }
}