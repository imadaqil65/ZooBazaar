namespace zooproject.Domain.Domain.Zoo
{
    public class Zone
    {
        public int ZoneId { get; private set; }
        public string Name { get; set; }

        public Zone()
        {

        }
        public Zone(string name)
        {
            Name = name;
        }
        public Zone(string name, int zoneid)
        {
            Name = name;
            ZoneId = zoneid;
        }
    }
}