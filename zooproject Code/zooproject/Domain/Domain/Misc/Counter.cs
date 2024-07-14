namespace zooproject
{
    public static class Counter
    {
        private static int CatCounter = 0;
        private static int BornInZooCounter = 0;
        private static int EditBornInZooCounter = 0;
        private static int KnownParentsCounter = 0;
        private static int BornOutsideZoo = 0;
        private static int AdoptedCounter = 0;
        public static int GetCatCounter()
        {
            if (CatCounter == 0) { return CatCounter++; }
            else { return CatCounter--; }
        }
        public static int GetBornInZooCounter()
        {
            if (BornInZooCounter == 0) { return BornInZooCounter++; }
            else { return BornInZooCounter--; }
        }
        public static int GetKnownParentsCounter()
        {
            if (KnownParentsCounter == 0) { return KnownParentsCounter++; }
            else { return KnownParentsCounter--; }
        }
        public static int GetBornOutsideZooCounter()
        {
            if (BornOutsideZoo == 0) { return BornOutsideZoo++; }
            else { return BornOutsideZoo--; }
        }

        public static int GetAdoptedCounter()
        {
            if (AdoptedCounter == 0) { return AdoptedCounter++; }
            else { return AdoptedCounter--; }
        }
        public static int GetEditBornInZooCounter()
        {
            if (EditBornInZooCounter == 0) { return EditBornInZooCounter++; }
            else { return EditBornInZooCounter--; }
        }
    }
}