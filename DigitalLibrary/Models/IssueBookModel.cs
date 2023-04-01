using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Models
{
    public class IssueBookModel
    {
        public string SelectPublication { get; set; }
        public string SelectBook { get; set; }
        public string BookName { get; set; }
        public int StudentId { get; set; }
        public int Days { get; set; }
        public DateTime IssueDate { get; set; }

    }
}