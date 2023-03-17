using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public class Monster : IThings, ITouchable
{
    public Transform Transform { get; set; }
    private Image sprite;

    public Size Size { get; private set; }
    public bool IsTouchedByPlayer { get; set; }

    public Monster(int type)
    {
        switch (type)
        {
            case 1:
                sprite = Resource1.enemy1r;
                Size = new Size(40, 40);
                break;
            case 2:
                sprite = Resource1.enemy2r;
                Size = new Size(70, 50);
                break;
            case 3:
                sprite = Resource1.enemy3r;
                Size = new Size(70, 60);
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
