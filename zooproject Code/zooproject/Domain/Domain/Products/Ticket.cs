using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Products
{
    public class Ticket
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string image { get; set; }

        public Ticket(string name, int price, string description, string image)
        {
            this.name = name;
            this.price = price;
            this.description = description;
            this.image = image;
        }
        public Ticket(int id, string name, int price, string description, string image)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.description = description;
            this.image = image;
        }
    }
}
