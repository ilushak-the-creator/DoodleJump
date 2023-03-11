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

        public float GetPositionX() => Transform.Position.X;
        public float GetPositionY() => Transform.Position.Y;
        public float GetWidth();
        public float GetHeight();
    }
}
