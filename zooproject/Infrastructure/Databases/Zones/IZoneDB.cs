using zooproject.Domain.Domain.Zoo;

namespace zooproject.Infrastructure.Databases.Zones
{
    public interface IZoneDB
    {
        public void AddZone(Zone z);
        public void DeleteZone(Zone z);
        public void UpdateZone(Zone z);
        public List<Zone> ReadAllZones();
        public Zone GetZoneWithID(int id);
    }
}