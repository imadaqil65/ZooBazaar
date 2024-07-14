using Domain.Domain.Products;
using Infrastructure.Databases.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

namespace Logic.Services.Products
{
    public class TicketManager
    {
        ITicket datasource;
        public TicketManager(ITicket datasource)
        {
            this.datasource = datasource;
        }

        public void CreateTicket(string name, int price, string description, string image)
        {
            Ticket newTicket = new Ticket(name, price, description, image);
            datasource.AddTicket(newTicket);
        }

        public List<Ticket> GetTickets()
        {
/*            List<Ticket> ticketList = new List<Ticket>();
            foreach (Ticket ticket in datasource.ReadAllTickets())
            {
                ticketList.Add(ticket);
            }*/
            return datasource.ReadAllTickets();
        }
        public void EditTickets(Ticket ticket)
        {
            datasource.UpdateTicket(ticket);
        }
        public void DeleteTickets(Ticket ticket)
        {
            datasource.RemoveTicket(ticket);
        }

        public Ticket GetTicket(int id)
        {
            return datasource.ReadTicket(id);
        }
    }
}
