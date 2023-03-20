using DoodleJump.Interfaces;
using DoodleJump.Models;
using DoodleJump.Models.Monsters;
using DoodleJump.Models.Busters;

namespace DoodleJump
{
    public class Physics
    {
        private float gravity;
        private const float acceleration = 0.4f;

        public void CalculatePhysics(Player player, IEnumerable <IEnumerable<IInteractable>> interactables)
        {
            if (player.Dx != 0)
            {
                player.Move();
            }
            if (player.InteractionModel.Position.Y < 700)
            {
                player.InteractionModel.Position.Y += gravity;
                gravity += acceleration;

                if (gravity >= -10)
                foreach (var item in interactables)
                {
                    Collision(player, item);
                }
            }
        }

        private void Collision(Player player, IEnumerable<IInteractable> items)
        {
            foreach (var item in items)
            {
                if (player.InteractionModel.IsCollideWith(item))
                {
                    if (item is Platform && gravity > 0)
                    {
                        gravity = -10;
                        item.IsTouchedByPlayer = true;
                        break;
                    }
                    if (item is Monster)
                    {
                        if (gravity > 0)
                        {
                            gravity = -10;
                            item.IsTouchedByPlayer = true;
                            break;
                        }
                        else
                        {
                            player.IsAlive = false;
                        }
                    }
                    if (item is Buster)
                    {
                        if (item is BusterRocket)
                        {
                            player.RocketBoost();
                            gravity = -40;
                        }
                        if (item is BusterSpring)
                            gravity = -20;
                        item.IsTouchedByPlayer = true; 
                        break;
                    }
                }
            }
        }
    }
}
