using DoodleJump.Models.Busters;
using DoodleJump.Models.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump.Factories
{
    public class BusterFactory
    {
        private int minBusterType = (int)Enum.GetValues<BusterType>().Min();
        private int maxBusterType = (int)Enum.GetValues<BusterType>().Max();

        public Buster CreateRandom()
        {
            var busterType = (BusterType)Random.Shared.Next(minBusterType, maxBusterType + 1);
            return Create(busterType);
        }

        private Buster Create(BusterType busterType) =>
            busterType switch
            {
                BusterType.Spring => new BusterSpring(),
                BusterType.Rocket => new BusterRocket(),
                _ => throw new ArgumentOutOfRangeException(nameof(busterType), $"Unsupported {nameof(BusterType)}")
            };
    }
}
