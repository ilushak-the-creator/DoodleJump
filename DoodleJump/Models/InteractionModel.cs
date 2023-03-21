using DoodleJump.Interfaces;

namespace DoodleJump.Models;

public class InteractionModel
{
    public PointF Position;
    public Size Size;

    public InteractionModel(PointF position, Size size)
    {
        Position = position;
        Size = size;
    }


    public bool IsCollideWith(IInteractable item) =>
         Position.X >= item.InteractionModel.Position.X - item.InteractionModel.Size.Width / 2
         && Position.X + Size.Width / 2 <= item.InteractionModel.Position.X + item.InteractionModel.Size.Width
         && Position.Y + Size.Height >= item.InteractionModel.Position.Y
         && Position.Y + Size.Height <= item.InteractionModel.Position.Y + item.InteractionModel.Size.Height;
}
