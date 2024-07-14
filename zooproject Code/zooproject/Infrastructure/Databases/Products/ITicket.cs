using Domain.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Databases.Products
{
    public interface ITicket
    {
        public void AddTicket(Ticket t);
        public void RemoveTicket(Ticket t);
        public void UpdateTicket(Ticket t);
        public List<Ticket> ReadAllTickets();
        public Ticket ReadTicket(int id);
    }
}
