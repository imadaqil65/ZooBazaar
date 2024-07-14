using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zooproject.Domain.Domain.Zoo;

namespace zooproject.Events
{
	public class ExhibitFilterEvent
	{
		public delegate void ExhibitFilterEventHandler(int ExhibitType, int ZoneID, int IsPreyPredetory);
		public event ExhibitFilterEventHandler ExhibitEvent;
		public ExhibitFilterEvent() { }

		public void SentFilteredExhibits(int ExhibitType, int ZoneID, int IsPreyPredetory)
		{
			ExhibitEvent(ExhibitType, ZoneID, IsPreyPredetory);
		}
	}
}
