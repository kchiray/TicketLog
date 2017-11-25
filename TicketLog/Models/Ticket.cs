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
        [Required]
        public DateTime SubmissionDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Issue")]
        public string Issue { get; set; }

        public string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Times Issue Has Occured")]
        public int TimesOccured { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Pick Severity")]
        public string Severity { get; set; }
    }
}
