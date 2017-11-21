using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLog.Models
{
    public class Ticket
    {
        public int ID { get; set; }
        public DateTime SubmissionDate { get; set; }
        public string Issue { get; set; }
        public string Description { get; set; }
        public int TimesOccured { get; set; }
        public string Severity { get; set; }
    }

    public enum Issues
    {
        Common = 1,
        Sparingly = 2,
        Rare = 3,
        Doom = 4
    };
    public class Issue
    {

        public int Id { get; set; }
        public Issues Issues { get; set; }

    }
}
