using Logic.Services.Cart;
using Infrastructure.Databases.Orders;
using zooproject.Domain.Domain.Misc;
using zooproject.Domain.Domain.Products;

namespace Logic.Services.Statistics
{
    public static class TicketStatisticsManager
    {
        private static OrderManager orderManager = new OrderManager(new DbOrder());
        private static List<Ticket> tickets= new List<Ticket>();

        public static void GetTickets(DateTime date)
        {
            tickets = orderManager.GetTicketsOfGivenWeek(DateTimeHandler.GivenDateWeekMonday(date), DateTimeHandler.GivenDateWeekSunday(date));
        }
        private static List<Ticket> GetUnusedTickets()
        {
            List<Ticket> UnusedTickets = new List<Ticket>();
            foreach (Ticket ticket in tickets.ToList())
            {
                if (ticket.LastUsed.Year == 1000)
                {
                    UnusedTickets.Add(ticket);
                }
            }
            return UnusedTickets;
        }
        public static Dictionary<DayOfWeek, int> GetAmountPerDay()
        {
            Dictionary<DayOfWeek, int> counted = new Dictionary<DayOfWeek, int>();
            foreach(DayOfWeek day in Enum.GetValues<DayOfWeek>())
            {
                int count = tickets.Count(t => t.Purchased.DayOfWeek == day);
                counted.Add(day, count);
            }
            return counted;
        }
        public static Dictionary<DayOfWeek, int> GetUnusedTicketAmountPerDay()
        {
            Dictionary<DayOfWeek, int> counted = new Dictionary<DayOfWeek, int>();
            foreach (DayOfWeek day in Enum.GetValues<DayOfWeek>())
            {
                int count = GetUnusedTickets().Count(t => t.Purchased.DayOfWeek == day);
                counted.Add(day, count);
            }
            return counted;
        }
    }
}