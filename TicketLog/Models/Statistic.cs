using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLog.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }             
        public int IncompleteApplications { get; set; }
        public int Emails { get; set; }
        public int NewApplicaitons { get; set; }
        public int ToDo { get; set; }
        public int YearToDate { get; set; }
    }
}
