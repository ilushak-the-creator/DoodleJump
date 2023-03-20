using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DoodleJump.Interfaces;

namespace DoodleJump.Models;

public class Player
{
    public InteractionModel InteractionModel { get; set; }
    public int Dx { get; private set; }
    public bool IsAlive { get; set; }

    public Image Sprite { get; set; }

    public Player()
    {
        Sprite = Resource1.man;
        InteractionModel = new InteractionModel(new PointF(100, 350), new Size(40, 40));
        IsAlive = true;
    }

    public void Stop() =>
        Dx = 0;

    public void SetDirectionLeft()
    {
        Sprite = Resource1.man;
        Dx = -6;
    }
    public void SetDirectionRight()
    {
        Sprite = Resource1.man_reverse;
        Dx = 6;
    }

    public void Shoot()
    {
        Sprite = Resource1.man_shooting;
    }

    public void RocketBoost()
    {
        Sprite = Resource1.man_jetpack;
    }

    public void Move() => InteractionModel.Position.X += Dx;
}
