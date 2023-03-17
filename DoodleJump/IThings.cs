using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public interface IThings : ITouchable
{
    public Transform Transform { get; set; }
    public Size Size { get; }

    public void DrawSprite(Graphics g);
}
