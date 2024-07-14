using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Domain.Domain.FilterObjects
{
    public class AnimalFilter
    {
        public int Species { get; set; }
        public int AnimalEnviroment { get; set; }
        public int ExhibitID { get; set; }
        public bool IsPredator { get; set; }
        public bool IsPrey { get; set; }
        public AnimalFilter(int species, int animalEnviroment, int exhibitID, bool isPredator, bool isPrey) 
        {
            Species = species;
            AnimalEnviroment = animalEnviroment;
            ExhibitID = exhibitID;
            IsPredator = isPredator;
            IsPrey = isPrey;
        }
    }
}
