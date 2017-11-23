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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Date")]
        public DateTime EntryDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Amount of Incomplete Apps")]
        public int IncompleteApplications { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Amount of Emails")]
        public int Emails { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Amount of New Apps")]
        public int NewApplicaitons { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter How Many Apps To Complete")]
        public int ToDo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Total Snowpass' Need to be Completed")]
        public int YearToDate { get; set; }
    }
}
