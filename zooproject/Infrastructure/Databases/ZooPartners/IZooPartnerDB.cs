using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Infrastructure.Databases.ZooPartners
{
    public interface IZooPartnerDB
    {
        public void AddZooPartner(ZooPartner zooPartner);
        public void RemoveZooPartner(ZooPartner zooPartner);
        public List<ZooPartner> GetAllZooPartners();
    }
}