using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public class Platform : IPlatform
{
    public Transform Transform;
    public bool IsTouchedByPlayer;
    public readonly int sizeX = 60;
    public readonly int sizeY = 12;
    private readonly Image sprite;

    public Platform(PointF position)
    {
        sprite = Resource1.platform;
        Transform = new Transform(position, new Size(sizeX, sizeY));
        IsTouchedByPlayer = false;
    }

    public void DrawSprite(Graphics g)
    {
        g.DrawImage(
            sprite,
            Transform.Position.X,
            Transform.Position.Y,
            Transform.Size.Width,
            Transform.Size.Height);
    }

}

