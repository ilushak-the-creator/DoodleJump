namespace DoodleJump
{
    public class Engine
    {
        public float dx;
        private float gravity;
        private float acceleration = 0.4f;
        private List<Platform> platforms;

        public Engine(List<Platform> platforms)
        {
            this.platforms = platforms;
        }

        public void CalculatePhysics(ICreature player)
        {
            if (dx != 0)
            {
                player.Transform.Position.X += dx;
            }
            if (player.Transform.Position.Y < 700)
            {
                player.Transform.Position.Y += gravity;
                gravity += acceleration;
                Collide(player);
            }
        }

        public void Collide(ICreature player)
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
            (platform.GetPositionX() <= player.GetWidth()
                && player.GetWidth() <= platform.GetWidth()
                && platform.GetPositionY() <= player.GetHeight()
                && player.GetHeight() <= platform.GetHeight());



    }
}
