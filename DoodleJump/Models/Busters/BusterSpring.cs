namespace DoodleJump.Models.Busters;

public class BusterSpring : Buster
{
    public BusterSpring() 
    {
        InteractionModel = new(default, new(18, 18));
        Sprite = Resource1.spring;
        IsTouchedByPlayer = false;
    }

    public override void UseBuster(Player player)
    {
        player.InteractionModel.Position.Y += 30;
    }
}
