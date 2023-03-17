using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public class Buster : IThings, ITouchable
{
    public Transform Transform { get; set; }
    private Image sprite;
    public Size Size { get; private set; }
    public bool IsTouchedByPlayer { get; set; }

    public Buster(int type)
    {
        switch (type)
        {
            case 1:
                sprite = Resource1.jetpack;
                Size = new Size(30, 30);
                break;
            case 2:
                sprite = Resource1.spring;
                Size = new Size(15, 15);
                break;
        }
    }

    public void DrawSprite(Graphics g) =>
        g.DrawImage(sprite,
            Transform.Position.X,
            Transform.Position.Y,
            Transform.Size.Width,
            Transform.Size.Height);
}
