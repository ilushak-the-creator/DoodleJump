using DoodleJump.Interfaces;
using DoodleJump.Models;

namespace DoodleJump.Extensions
{
    public static class GraphicsExtensions
    {
        public static void DrawImage(this Graphics graphics, IInteractable item)
        {
            graphics.DrawImage(
                item.Sprite,
                item.InteractionModel.Position.X,
                item.InteractionModel.Position.Y,
                item.InteractionModel.Size.Width,
                item.InteractionModel.Size.Height);
        }

        public static void DrawImage(this Graphics graphics, Player player)
        {
            graphics.DrawImage(
                player.Sprite,
                player.InteractionModel.Position.X,
                player.InteractionModel.Position.Y,
                player.InteractionModel.Size.Width,
                player.InteractionModel.Size.Height);
        }
    }
}
