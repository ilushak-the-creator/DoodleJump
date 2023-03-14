using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public class Player : ICreature
{
    public Transform Transform { get; set; }
    public int Dx { get; private set; }
    private Image sprite;

    public Player()
    {
        sprite = Resource1.man;
        Transform = new Transform(new PointF(100, 350), new Size(40, 40));
    }

    public void DontMove() => Dx = 0;
    public void MoveLeft()
    {
        sprite = Resource1.man;
        Dx = -6;
    }
    public void MoveRight()
    {
        sprite = Resource1.man_reverse;
        Dx = 6;
    }

    public void DrawSprite(Graphics g) =>
        g.DrawImage(sprite, 
            Transform.Position.X, 
            Transform.Position.Y, 
            Transform.Size.Width, 
            Transform.Size.Height);


}
