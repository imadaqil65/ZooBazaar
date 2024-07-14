using zooproject.Domain.Domain.Enums;
namespace zooproject.Domain.Domain.Zoo
{
    public class Animal
    {
        private readonly int id;

        public int IDAuto => id;
        public string Name { get; set; }
        public AnimalSpecies Species { get; set; }
        public DateTime EnterDate { get; set; }
        public string Origin { get; set; }
        public Gender AnimalGender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Diet { get; set; }
        public DateTime LeavingDate { get; set; }
        public string LeavingReason { get; set; }
        public string Notes { get; set; }
        public string ID { get; set; }
        public string Relations { get; set; }
        public int exhibitID { get; set; }
        public bool IsPredator { get; set; }
        public bool IsPrey { get; set; }

        public Animal(string name, AnimalSpecies species, DateTime enterdate, string origin, Gender animalgender, DateTime dateofbirth, string diet, string notes, string relations, int exhibitiD, bool isPredator, bool isPrey)
        {
            Name = name;
            Species = species;
            EnterDate = enterdate;
            Origin = origin;
            AnimalGender = animalgender;
            DateOfBirth = dateofbirth;
            Diet = diet;
            AnimalGender = animalgender;
            Notes = notes;
            Relations = relations;
            exhibitID = exhibitiD;
            IsPredator = isPredator;
            this.IsPrey = isPrey;
            LeavingReason = "";
            ID = AnimaldGenerator.GetAnimalID(species, enterdate);
        }
        public Animal(string name, AnimalSpecies species, DateTime enterdate, string origin, Gender animalgender, DateTime dateofbirth, string diet, string notes, string iD, string relations, int exhibitiD, bool isPredator, bool isPrey)
        {
            Name = name;
            Species = species;
            EnterDate = enterdate;
            Origin = origin;
            AnimalGender = animalgender;
            DateOfBirth = dateofbirth;
            Diet = diet;
            AnimalGender = animalgender;
            Notes = notes;
            ID = iD;
            Relations = relations;
            exhibitID = exhibitiD;
            IsPredator = isPredator;
            this.IsPrey = isPrey;
            LeavingReason = "";
        }
        public Animal(int id, string name, AnimalSpecies species, DateTime enterdate, string origin, Gender animalgender, DateTime dateofbirth, string diet, string notes, string iD, string relations, int exhibitiD, bool isPredator, bool isPrey, DateTime leavingDate, string leavingReason)
        {
            this.id = id;
            Name = name;
            Species = species;
            EnterDate = enterdate;
            Origin = origin;
            AnimalGender = animalgender;
            DateOfBirth = dateofbirth;
            Diet = diet;
            AnimalGender = animalgender;
            Notes = notes;
            ID = iD;
            Relations = relations;
            exhibitID = exhibitiD;
            IsPredator = isPredator;
            this.IsPrey = isPrey;
            LeavingDate = leavingDate;
            LeavingReason = leavingReason;
        }
        public int GetAnimalAge()
        {
            return Calculator.ToAge(this.DateOfBirth);
        }
        public int GetTimeStayed()
        {
            return Calculator.ToTimeStayed(this.EnterDate, (DateTime)this.LeavingDate);
        }
    }
}