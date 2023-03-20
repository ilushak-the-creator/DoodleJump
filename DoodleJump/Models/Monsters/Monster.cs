using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoodleJump.Interfaces;

namespace DoodleJump.Models.Monsters;

public abstract class Monster : IInteractable
{
    public InteractionModel InteractionModel { get; set; }
    public Image Sprite { get; set; }
    public bool IsTouchedByPlayer { get; set; }

    public Monster()
    {
        //switch (type)
        //{
        //    case MonsterType.First:
        //        Sprite = Resource1.enemy1r;
        //        Size = new Size(40, 40);
        //        break;
        //    case MonsterType.Second:
        //        Sprite = Resource1.enemy2r;
        //        Size = new Size(70, 50);
        //        break;
        //    case MonsterType.Third:
        //        Sprite = Resource1.enemy3r;
        //        Size = new Size(70, 60);
        //        break;
        //}
    }
}
