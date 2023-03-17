using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public static class Game
{
    private static int score = 0;

    private static int startPlatformPosY = 400;
    private static List<Platform> platforms = new();
    private static List<IThings> things = new();

    private static Physics physics = new Physics();
    private static Player player = new Player();

    private static Random rand = new Random();

    public static void AddScore(int size) => score += size;
    public static int GetScore() => score;
    public static void ResetScore() => score = 0;

    public static void Restart()
    {
        ResetScore();
        platforms.Clear();
        things.Clear();
        startPlatformPosY = 400;
        GenerateStartSequence();
        physics = new Physics();
        player = new Player();
    }

    public static bool IsEnd() => player.Transform.Position.Y >= platforms.First().Transform.Position.Y + 200;

    public static void Update()
    {
        var scoreT = score;
        physics.CalculatePhysics(player, platforms, things);
        FollowPlayer();
        MovePlayerThrowWalls();
        ClearPlatforms();
        ClearThings();
        if (scoreT != score) 
        {
            GenerateRandomPlatform();
        }
    }

    public static void DrawGraphics(Graphics g)
    {
        DrawPlatforms(g);
        DrawPlayer(g);
        DrawThings(g);
    }
    public static void PlayerDontMove() => player.DontMove();
    public static void MovePlayerLeft() => player.MoveLeft();
    public static void MovePlayerRight() => player.MoveRight();

    private static void GenerateStartSequence()
    {
        platforms.Add(new(new PointF(100, 400)));
        for (int i = 0; i < 10; i++)
        {
            int x = rand.Next(0, 270);
            int y = rand.Next(50, 60);
            startPlatformPosY -= y;
            var position = new PointF(x, startPlatformPosY);
            var platform = new Platform(position);
            platforms.Add(platform);
            
        }
    }

    private static void GenerateRandomPlatform()
    {
        var x = rand.Next(0, 270);
        var position = new PointF(x, startPlatformPosY);
        var platform = new Platform(position);
        platforms.Add(platform);
        SpawnRandomThingsOnPlatform(platform);

    }
    private static void DrawPlatforms(Graphics g)
    {
        foreach (var platform in platforms)
        {
            platform.DrawSprite(g);
        }
    }

    private static void ClearPlatforms()
    {
        if (!platforms.Any()) return;
        for (var i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].Transform.Position.Y >= 700)
            {
                platforms.RemoveAt(i);
            }
        }
    }

    private static void ClearThings()
    {
        if (!things.Any()) return; 
        for (var i = 0; i < things.Count; i++)
        {
            if (things[i].Transform.Position.Y >= 700)
            {
                things.RemoveAt(i);
            }
        }
    }

    private static void FollowPlayer()
    {
        var offset = 400 - (int)player.Transform.Position.Y;
        player.Transform.Position.Y += offset;

        foreach (var platform in platforms)
        {
            platform.Transform.Position.Y += offset;
        }
        foreach(var item in things)
        {
            item.Transform.Position.Y += offset;
        }
    }

    private static void DrawPlayer(Graphics g) => player.DrawSprite(g);
    private static void MovePlayerThrowWalls()
    {
        if (player.Transform.Position.X < -20)
        {
            player.Transform.Position.X = 300;
        }
        if (player.Transform.Position.X > 300)
        {
            player.Transform.Position.X = -20;
        }
    }

    private static Transform PlaceOnPlatform(Platform platform, IThings item) =>
        new Transform(new PointF(
            platform.Transform.Position.X + platform.Transform.Size.Width / 2 - item.Size.Width / 2,
            platform.Transform.Position.Y - item.Size.Height),
            item.Size);


    private static void SpawnRandomThingsOnPlatform(Platform platform)
    {
        var chance = rand.Next(1, 10);

        if (chance == 1)
        {
            GenerateRandomMonster(platform);
        }
        if (chance == 2) 
        {
            GenerateRandomBuster(platform);
        }
    }
    private static void GenerateRandomMonster(Platform platform)
    {
        var monsterType = rand.Next(1, 3);
        var monster = new Monster(monsterType);
        monster.Transform = PlaceOnPlatform(platform, monster);


        things.Add(monster);
    }

    private static void GenerateRandomBuster(Platform platform)
    {
        var busterType = rand.Next(1, 2);
        var buster = new Buster(busterType);
        buster.Transform = PlaceOnPlatform(platform, buster);


        things.Add(buster);
    }

    private static void DrawThings(Graphics g)
    {
        foreach (var item in things)
        {
            item.DrawSprite(g);
        }
    }

    public static void PlayerShoot()
    {
        player.Shoot();
        foreach (var item in things)
        {
            if (item.Transform.Position.Y > 0 && item.GetType() == typeof(Monster))
            {
                things.Remove(item);
                break;
            }
        }
    }

    public static void KillMonster(Monster monster)
    {
        things.Remove(monster);
    }
}
