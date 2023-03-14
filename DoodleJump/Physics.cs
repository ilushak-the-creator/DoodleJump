namespace DoodleJump
{
    public class Physics
    {
        private float gravity;
        private const float acceleration = 0.4f;


        public void CalculatePhysics(ICreature player, List<Platform> platforms)
        {
            if (player.Dx != 0)
            {
                player.Transform.Position.X += player.Dx;
            }
            if (player.Transform.Position.Y < 700)
            {
                player.Transform.Position.Y += gravity;
                gravity += acceleration;
                Collide(player, platforms);
            }
        }

        public void Collide(ICreature player, List<Platform> platforms)
        {
            for (var i = 0; i < platforms.Count; i++)
            {
                var platform = platforms[i];
                if (IsPlayerTouchedPlatform(player, platform) && gravity > 0)
                {
                    gravity = -10;

                    if (!platform.IsTouchedByPlayer)
                    {
                        Game.AddScore(20);
                        platform.IsTouchedByPlayer = true;
                        Game.GenerateRandomPlatform();
                        Game.ClearPlatforms();
                    }
                }
            }
        }

        private static bool IsPlayerTouchedPlatform(ICreature player, Platform platform) =>
            (player.Transform.Position.X >= platform.Transform.Position.X - 30
                && player.Transform.Position.X <= platform.Transform.Position.X + 30
                &&  player.Transform.GetHeight() >= platform.Transform.Position.Y 
                && player.Transform.GetHeight() <= platform.Transform.GetHeight());



    }
}
