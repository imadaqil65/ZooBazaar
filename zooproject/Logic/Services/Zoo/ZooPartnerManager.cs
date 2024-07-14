using zooproject.Infrastructure.Databases.ZooPartners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Logic.Services.Zoo
{
    public class ZooPartnerManager
    {
        IZooPartnerDB datasource;
        public ZooPartnerManager(ZooPartnerDB source) 
        {
            datasource = source;
        }
        public void AddZooPartner(ZooPartner zooPartner)
        {
            datasource.AddZooPartner(zooPartner);
        }
        public void RemoveZooPartner(ZooPartner zooPartner)
        {
            datasource.RemoveZooPartner(zooPartner);
        }
        public List<ZooPartner> GetAllZooPartners() 
        { 
            return datasource.GetAllZooPartners();
        }
    }
}