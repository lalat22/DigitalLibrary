using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Detail { get; set; }
        public decimal Price { get; set; } 
        public string Publication { get; set; }
        public string Branch { get; set; }
        public int Quantities { get; set;}
        public int AvlQuantity { get; set;}
        public int RentQuantity { get; set;}
        public string Images { get; set;}
    }
}