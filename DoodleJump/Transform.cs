using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public class Transform
{
    public PointF Position;
    public Size Size;

    public Transform(PointF position, Size size)
    {
        Position = position;
        Size = size;
    }

    public float GetWidth() => Position.X + Size.Width;

    public float GetHeight() => Position.Y + Size.Height;

    public bool IsCollideWith(ITouchable item) =>
         Position.X >= item.Transform.Position.X - item.Transform.Size.Width / 2
         && Position.X + Size.Width / 2 <= item.Transform.Position.X + item.Transform.Size.Width
         && Position.Y + Size.Height >= item.Transform.Position.Y
         && Position.Y + Size.Height <= item.Transform.Position.Y + item.Transform.Size.Height;
}
