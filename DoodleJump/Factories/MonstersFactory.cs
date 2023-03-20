using DoodleJump.Models.Monsters;

namespace DoodleJump.Factories
{
    public class MonstersFactory
    {
        private int minMonsterType = (int)Enum.GetValues<MonsterType>().Min();
        private int maxMonsterType = (int)Enum.GetValues<MonsterType>().Max();

        //private readonly MonsterSettings monsterSettings1;

        public Monster CreateRandom()
        {
            var monsterType = (MonsterType)Random.Shared.Next(minMonsterType, maxMonsterType);
            return Create(/*monsterType*/MonsterType.First);
        }

        private Monster Create(MonsterType monsterType) =>
            monsterType switch
            {
                MonsterType.First => new MonsterFirst(),
                MonsterType.Second => throw new NotImplementedException(),
                MonsterType.Third => throw new NotImplementedException(),
                _ => throw new ArgumentOutOfRangeException(nameof(monsterType), $"Unsupported {nameof(MonsterType)}")
            };
        
    }
}
