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
        private static int ExternalMoveCounter = 0;
        private static int MoveModifyAnimalFormCounter = 0;

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
        public static void ResetAddAnimalCounter()
        {
            BornInZooCounter = 0;
			KnownParentsCounter = 0;
			BornOutsideZoo = 0;
			AdoptedCounter = 0;
		}

        public static int GetExternalMoveCounter()
        {
            if (ExternalMoveCounter == 0) { return ExternalMoveCounter++; }
            else { return ExternalMoveCounter--; }
        }
        public static int GetMoveModifyAnimalFormCounter()
        {
            return MoveModifyAnimalFormCounter;
        }
        public static void UpdateMoveModifyAnimalFormCounter()
        {
            if (MoveModifyAnimalFormCounter == 0)
            {
                MoveModifyAnimalFormCounter = 1;
            }
            else if (MoveModifyAnimalFormCounter == 1)
            {
                MoveModifyAnimalFormCounter = 0;
            }
        }
    }
}