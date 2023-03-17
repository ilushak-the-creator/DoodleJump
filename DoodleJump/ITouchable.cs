using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public interface ITouchable
{
    public Transform Transform { get; set; }
    public bool IsTouchedByPlayer { get; set; }
}
