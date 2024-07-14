using Domain.Domain.Enums;
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
        public EnviromentType AnimalEnviroment { get; set; }
        public int FeedingPeriod { get; set; } //In Days
        public static bool ApplyPeriodAllMembersOfClass { get; private set; } //Save to seperate table called staticclassvalues
        public FeedingTimeSlot PreferedSlot { get; set; }

        /// <summary>
        /// Create new Animal
        /// </summary>
        /// <param name="name"></param>
        /// <param name="species"></param>
        /// <param name="enterdate"></param>
        /// <param name="origin"></param>
        /// <param name="animalgender"></param>
        /// <param name="dateofbirth"></param>
        /// <param name="diet"></param>
        /// <param name="notes"></param>
        /// <param name="relations"></param>
        /// <param name="exhibitiD"></param>
        /// <param name="isPredator"></param>
        /// <param name="isPrey"></param>
        /// <param name="animalEnviroment"></param>
        /// <param name="feedingPeriod"></param>
        /// <param name="timeSlot"></param>
        public Animal(string name, AnimalSpecies species, DateTime enterdate, string origin, Gender animalgender, DateTime dateofbirth, string diet, string notes, string relations, int exhibitiD, bool isPredator, bool isPrey, EnviromentType animalEnviroment, int feedingPeriod, FeedingTimeSlot timeSlot)
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
            AnimalEnviroment = animalEnviroment;
            FeedingPeriod = feedingPeriod;
            PreferedSlot = timeSlot;
        }
        public Animal(string name, AnimalSpecies species, DateTime enterdate, string origin, Gender animalgender, DateTime dateofbirth, string diet, string notes, string iD, string relations, int exhibitiD, bool isPredator, bool isPrey, EnviromentType animalEnviroment, int feedingPeriod, FeedingTimeSlot timeSlot)
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
            AnimalEnviroment = animalEnviroment;
            FeedingPeriod = feedingPeriod;
            PreferedSlot = timeSlot;
        }
        /// <summary>
        /// Read Animal
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="species"></param>
        /// <param name="enterdate"></param>
        /// <param name="origin"></param>
        /// <param name="animalgender"></param>
        /// <param name="dateofbirth"></param>
        /// <param name="diet"></param>
        /// <param name="notes"></param>
        /// <param name="iD"></param>
        /// <param name="relations"></param>
        /// <param name="exhibitiD"></param>
        /// <param name="isPredator"></param>
        /// <param name="isPrey"></param>
        /// <param name="animalEnviroment"></param>
        /// <param name="leavingDate"></param>
        /// <param name="leavingReason"></param>
        /// <param name="feedingPeriod"></param>
        /// <param name="timeSlot"></param>
        public Animal(int id, string name, AnimalSpecies species, DateTime enterdate, string origin, Gender animalgender, DateTime dateofbirth, string diet, string notes, string iD, string relations, int exhibitiD, bool isPredator, bool isPrey, EnviromentType animalEnviroment, DateTime leavingDate, string leavingReason, int feedingPeriod, FeedingTimeSlot timeSlot)
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
            AnimalEnviroment = animalEnviroment;
            FeedingPeriod = feedingPeriod;
            PreferedSlot = timeSlot;
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