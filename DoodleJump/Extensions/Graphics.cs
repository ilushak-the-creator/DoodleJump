using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DoodleJump.Interfaces;
using DoodleJump.Models;
using DoodleJump.Models.Monsters;

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
