using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public class Player : ICreature
{
    public Transform Transform { get; set; }
    private readonly Image sprite;

    public Player()
    {
        sprite = Resource1.man2;
        Transform = new Transform(new PointF(100, 350), new Size(40, 40));
    }

    public float GetPositionX() => Transform.Position.X;
    public float GetPositionY() => Transform.Position.Y;
    public float GetWidth() => Transform.GetWidth();
    public float GetHeight() => Transform.GetHeight();

    public void DrawSprite(Graphics g)
    {
        g.DrawImage(sprite, GetPositionX(), GetPositionY(), Transform.Size.Width, Transform.Size.Height);
    }

}
