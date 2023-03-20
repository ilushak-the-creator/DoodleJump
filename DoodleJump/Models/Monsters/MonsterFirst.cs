

namespace DoodleJump.Models.Monsters;

public class MonsterFirst : Monster
{
    public MonsterFirst()
    {
        InteractionModel = new(default, new(40, 40));
        Sprite = Resource1.enemy1r;
        IsTouchedByPlayer = false;
    }
}
