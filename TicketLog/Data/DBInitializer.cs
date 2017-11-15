using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketLog.Models;

namespace TicketLog.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //Look for any tickets
            context.Database.EnsureCreated();
            if (context.Tickets.Any())
            {
                return; //DB has been seeded
            }

            var tickets = new Ticket[]
            {
                new Ticket {ID=1, Issue="Apply Button", Description="Apply button not working",
                            Severity ="Threat Level Midnight", TimesOccured=58, TicketDate=DateTime.Parse("2017-11-14") }
            };
            foreach (Ticket t in tickets)
            {
                context.Tickets.Add(t);
            } context.SaveChanges();
            {

            }
            //    ID { get; set; 
            //    Time TicketDate
            //    ng Issue
            //{
            //    get;
            //    ng Description
            //    TimesOccured
            //    {
            //        ng Severity {
            //            g
            //    {
        }
    }
}
