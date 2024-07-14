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
        static public int CalculateAmountOfTasks(DateTime start, DateTime end, int period)
        {
            TimeSpan difference = end - start;
            double delta = Convert.ToDouble(difference.Days);
            int amount = (int)Math.Round(delta / period);
            return amount;
        }

        static public int CalculateAmountOfDays(DateTime start, DateTime end)
        {
            return Convert.ToInt32(end.Date.Day - start.Date.Day);
        }
    }
}