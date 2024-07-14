namespace zooproject.Domain.Domain.Zoo
{
    public class ZooPartner
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ZooPartner(string name)
        {
            Name = name;
        }
        public ZooPartner(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}