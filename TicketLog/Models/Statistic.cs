using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLog.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public String EntryDate { get { return DateTime.Now.ToString("dd/mm/yyyy"); } }
        public int Emails { get; set; }
        public int NewApplicaitons { get; set; }
        public int ToDo { get; set; }
        public int YearToDate { get; set; }
    }
}
