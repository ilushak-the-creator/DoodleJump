using DoodleJump.Models;

namespace DoodleJump.Interfaces;

public interface IInteractable
{
    public InteractionModel InteractionModel { get; set; }
    public Image Sprite { get; set; }

    public bool IsTouchedByPlayer { get; set; }
}
