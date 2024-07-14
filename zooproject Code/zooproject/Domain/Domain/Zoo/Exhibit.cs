namespace zooproject.Domain.Domain.Zoo
{
    public class Exhibit
    {
        public int Id { get; private set; }
        public int ZoneId { get; set; }
        public string Name { get; set; }
        public bool PredatorOrPrey { get; set; } //True == Predator, False == Prey
        public EnviromentType ExhibitType { get; set; }
        public Exhibit(string name, bool predatororprey, EnviromentType exhibittype/*, int zoneid*/)
        {
            Name = name;
            PredatorOrPrey = predatororprey;
            ExhibitType = exhibittype;
            //ZoneId = zoneid;
        }

        public Exhibit(int id, string name, bool predatororprey, EnviromentType exhibittype/*, int zoneid*/)
        {
            Id = id;
            Name = name;
            PredatorOrPrey = predatororprey;
            ExhibitType = exhibittype;
            //ZoneId = zoneid;
        }
    }
}