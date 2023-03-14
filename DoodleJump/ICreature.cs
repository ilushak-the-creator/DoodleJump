using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump
{
    public interface ICreature
    {
        public Transform Transform { get; }
        public int Dx { get; }

        public void DrawSprite(Graphics g);
    }
}
