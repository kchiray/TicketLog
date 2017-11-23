using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLog.Models
{    
    public class Ticket
    {           
        public int ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime SubmissionDate { get; set; }
        public string Issue { get; set; }
        public string Description { get; set; }
        public int TimesOccured { get; set; }
        public string Severity { get; set; }
    }
}
