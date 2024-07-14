namespace zooproject
{
    static public class Calculator
    {
        static public int ToAge(DateTime BirthDate)
        {
            return Convert.ToInt32(Convert.ToInt32(DateTime.Now.Year) - Convert.ToInt32(BirthDate.Year));
        }
        static public int ToTimeStayed(DateTime EnterDate, DateTime LeavingDate)
        {
            return Convert.ToInt32(LeavingDate.Date - EnterDate.Date);
        }
    }
}