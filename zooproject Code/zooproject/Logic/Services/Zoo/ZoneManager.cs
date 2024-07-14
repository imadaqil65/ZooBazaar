using zooproject.Domain.Domain.Zoo;
using zooproject.Infrastructure.Databases.Zones;

namespace zooproject.Logic.Services.Zoo
{
    public class ZoneManager
    {
        IZoneDB datasource;
        public ZoneManager(IZoneDB source)
        {
            datasource = source;
        }
        public void CreateZone(string name)
        {
            Zone newZone = new Zone(name);
            datasource.AddZone(newZone);
        }
        public void EditZone(Zone zone)
        {
            datasource.UpdateZone(zone);
        }

        public void RemoveZone(Zone zone)
        {
            datasource.DeleteZone(zone);
        }

        public List<Zone> GetAllZones()
        {
            List<Zone> result = datasource.ReadAllZones();
            return result;
        }
    }
}