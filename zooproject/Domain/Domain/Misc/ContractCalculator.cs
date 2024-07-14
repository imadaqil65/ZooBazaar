using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Domain.Misc
{
    static public class ContractCalculator
    {
        static public int CalculateFTE(decimal FTE)
        {
            return Convert.ToInt32(FTE*40);   
        }

        static public decimal TurnToDecimal(int FTE)
        {
            decimal fte = Convert.ToDecimal(FTE);
            return fte / 40;
        }
    }
}
