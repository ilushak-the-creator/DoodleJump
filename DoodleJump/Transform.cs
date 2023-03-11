using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump
{
    public class Transform
    {
        public PointF Position;
        public Size Size;

        public Transform(PointF position, Size size)
        {
            this.Position = position;
            this.Size = size;
        }

        public float GetWidth() => Position.X + Size.Width;

        public float GetHeight() => Position.Y + Size.Height;
    }
}
