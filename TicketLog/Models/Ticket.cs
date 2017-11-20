using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLog.Models
{   
    public class Ticket
    {
        public int ID { get; set; }        
        public DateTime SubmissionDate { get { return DateTime.Now.Date; } }
        public string Issue { get; set; }
        public string Description { get; set; }
        public int TimesOccured { get; set; }
        public string Severity { get; set; }
    }
}
