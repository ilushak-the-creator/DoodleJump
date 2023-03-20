using DoodleJump.Interfaces;

namespace DoodleJump.Models.Busters;

public abstract class Buster : IInteractable
{
    public InteractionModel InteractionModel { get; set; } 
    public Image Sprite { get; set; }
    public bool IsTouchedByPlayer { get; set; }

    public abstract void UseBuster(Player player);
}
