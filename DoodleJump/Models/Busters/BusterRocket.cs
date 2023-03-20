namespace DoodleJump.Models.Busters;

public class BusterRocket : Buster
{
    public BusterRocket()
    {
        InteractionModel = new(default, new(30, 30));
        Sprite = Resource1.jetpack;
        IsTouchedByPlayer = false;
    }

    public override void UseBuster(Player player)
    {
        player.InteractionModel.Position.Y -= 200;
    }
}
