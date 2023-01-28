using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalLibrary.Models
{
    public class PublicationModel
    {
        public int PublicationId { get; set; }
        public string PublicationName { get; set;}
        public DateTime CreatedDate { get; set;}  
    }
}