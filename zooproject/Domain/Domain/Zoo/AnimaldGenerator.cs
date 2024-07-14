namespace zooproject.Domain.Domain.Zoo
{
    public static class AnimaldGenerator
    {
        public static string GetAnimalID(AnimalSpecies species, DateTime enterDate)
        {
            string animalId = (enterDate.Year.ToString() + Convert.ToString(species).Substring(0, 2));
            return animalId;
        }
        //For Future Refrence
        //public static string GetAnimalID(AnimalSpecies species, DateTime enterDate)
        //{
        //    throw new NotImplementedException();
        //    int highestNumber = 0;
        //    List<string> AnimalIds = DataBase.GetAllIDsFromSpecificSpecies(species);
        //    foreach (string aString in AnimalIds)
        //    {
        //        int numberPart = Convert.ToInt32(aString.Substring(7, 15));
        //        if (numberPart > highestNumber)
        //        {
        //            highestNumber = numberPart;
        //        }
        //    }
        //    string animalId = (enterDate.Year.ToString() + Convert.ToString(species).Substring(0, 2) + Convert.ToString(highestNumber));
        //    return animalId;
        //}
    }
}