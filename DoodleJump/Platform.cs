using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public class Platform : IPlatform, ITouchable
{
    public Transform Transform { get; set; }
    public bool IsTouchedByPlayer { get; set; }
    private readonly Size size = new Size(60, 12);
    private readonly Image sprite;


    public Platform(PointF position)
    {
        sprite = Resource1.platform;
        Transform = new Transform(position, size);
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

