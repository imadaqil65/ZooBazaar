using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Enums;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Domain.Domain.FilterObjects
{
    public class ExhibitFilter
    {
        public EnviromentType ExhibitType { get; set; }
        public int ZoneID { get; set; }
        public int IsPreyPredetory { get; set; }
        public ExhibitFilter(EnviromentType exhibitType, int isPreyPredetory) 
        { 
            ExhibitType = exhibitType;
            IsPreyPredetory = isPreyPredetory;
        }
        //need to add zone stuff
    }
}
