using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using DoodleJump.Models;

namespace DoodleJump.Interfaces;

public interface IInteractable
{
    public InteractionModel InteractionModel { get; set; }
    public Image Sprite { get; set; }

    public bool IsTouchedByPlayer { get; set; }
}
