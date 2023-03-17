namespace DoodleJump
{
    public class Physics
    {
        private float gravity;
        private const float acceleration = 0.4f;


        public void CalculatePhysics(Player player, IEnumerable<ITouchable> platforms, IEnumerable<ITouchable> things)
        {
            if (player.Dx != 0)
            {
                player.Move();
            }
            if (player.Transform.Position.Y < 700)
            {
                player.Transform.Position.Y += gravity;
                gravity += acceleration;
                Collide(player, platforms);
                Collide(player, things);
            }
        }

        private void Collide(Player player, IEnumerable<ITouchable> items)
        {
            foreach (var item in items)
            {
                if (player.Transform.IsCollideWith(item))
                {
                    if (gravity > 0 && item.GetType() == typeof(Platform))
                    {
                        gravity = -10;

                        if (!item.IsTouchedByPlayer)
                        {
                            Game.AddScore(20);
                            item.IsTouchedByPlayer = true;
                        }
                    }
                    if (item.GetType() == typeof(Monster))
                    {
                        if (gravity > 0)
                        {
                            gravity = -10;
                            Game.KillMonster((Monster)item);
                            Game.AddScore(50);
                        }
                        else
                            Game.Restart();
                        break;
                    }
                    if (item.GetType() == typeof(Buster))
                    {
                        gravity = -20;
                        Game.AddScore(20);
                    }
                }
            }
        }
    }
}
