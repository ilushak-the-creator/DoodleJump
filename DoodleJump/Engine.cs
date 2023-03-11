namespace DoodleJump
{
    public class Engine
    {
        public float dx;
        private float gravity;
        private float acceleration = 0.4f;



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
            for (var i = 0; i < Game.Platforms.Count; i++)
            {
                var platform = Game.Platforms[i];
                if (IsPlayerTouchedPlatform(player, platform) && gravity > 0)
                {
                    gravity = -10;
                    if (!platform.IsTouchedByPlayer)
                    {
                        Game.Score += 20;
                        platform.IsTouchedByPlayer = true;
                        Game.GenerateRandomPlatform();
                        Game.ClearPlatforms();
                    }
                }
            }
        }

        private bool IsPlayerTouchedPlatform(ICreature player, Platform platform) =>
            (platform.GetPositionX() <= player.GetWidth()
                && player.GetWidth() <= platform.GetWidth()
                && platform.GetPositionY() <= player.GetHeight()
                && player.GetHeight() <= platform.GetHeight());



    }
}
