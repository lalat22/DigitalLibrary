using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Models
{
    public class ReturnBookModel
    {
        public string Author { get; set; }
        public string Publication { get; set; }
        public string Branch { get; set; }
        public decimal Price { get; set; }
        public string StudentName { get; set; }
        public int Days { get; set; }
        public DateTime IssueDate { get; set; }
        //public string PnalityStatus { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int RentId { get; set; }
        public string Images { get; set;}
    }
}