using DoodleJump.Interfaces;

namespace DoodleJump.Models;

public class Platform : IInteractable
{
    public InteractionModel InteractionModel { get; set; }
    public Image Sprite { get; set; }
    public bool IsTouchedByPlayer { get; set; }

    private readonly Size size = new Size(60, 12);


    public Platform(PointF position)
    {
        Sprite = Resource1.platform;
        InteractionModel = new InteractionModel(position, size);
        IsTouchedByPlayer = false;
    }
}

