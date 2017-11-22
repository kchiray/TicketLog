using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLog.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public DateTime EntryDate
        {
            get
            {
                DateTime entryDate = new DateTime();
                return entryDate.Date;
            }
            set
            {
                EntryDate = value;
            }
        }
        public int IncompleteApplications { get; set; }
        public int Emails { get; set; }
        public int NewApplicaitons { get; set; }
        public int ToDo { get; set; }
        public int YearToDate { get; set; }
    }
}
