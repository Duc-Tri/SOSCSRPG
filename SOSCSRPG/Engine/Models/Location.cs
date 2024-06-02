using Engine.Factories;

namespace Engine.Models
{
    public class Location
    {
        #region Properties
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public List<Quest> QuestsAvailableHere { get; set; } = new List<Quest>();

        public List<MonsterEncounter> MonstersHere { get; set; } = new List<MonsterEncounter>();

        public Trader TraderHere { get; set; }

        #endregion

        public void AddMonster(int monsterID, int chanceOfEncountering)
        {
            if (MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                // This monster has already been added to this location.
                // So, overwrite the ChanceOfEncountering with the new number
                MonstersHere.First(m => m.MonsterID == monsterID).ChanceOfEncountering = chanceOfEncountering;
            }
            else
            {
                // This monster is not already at this location, so add it
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncountering));
            }
        }

        public Monster GetMonster()
        {
            if (!MonstersHere.Any())
                return null;

            // Total the percentage of all monsters at this location
            int totalChance = MonstersHere.Sum(m => m.ChanceOfEncountering);

            // Select a random number between 1 and the total
            int randomNumber = RandomNumberGenerator.NumberBetween(1, totalChance);

            // Loop through the monster list, adding the monster's percentage chance of arrpearing to the runningTotal variable.
            // When the random number is lower than the runningTotal, that is the monster to return
            int runningTotal = 0;
            foreach (MonsterEncounter monsterEncounter in MonstersHere)
            {
                runningTotal += monsterEncounter.ChanceOfEncountering;
                if (randomNumber <= runningTotal)
                    return MonsterFactory.GetMonster(monsterEncounter.MonsterID);
            }

            // SHOULD NEVER HAPPEN ?!?
            // if there was a problemn, return the last monster in the list
            return MonsterFactory.GetMonster(MonstersHere.Last().MonsterID);
        }

    }

}
