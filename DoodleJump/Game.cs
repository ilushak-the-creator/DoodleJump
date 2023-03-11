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
    private static readonly Platform startPlatform = new(new PointF(100, 400));
    private static List<Platform> platforms = new List<Platform>();

    private static Engine engine = new Engine(platforms);
    private static Player player = new Player();

    public static void AddScore(int size) => score += size;
    public static int GetScore() => score;
    public static void ResetScore() => score = 0;

    public static void RestartGame()
    {
        ResetScore();
        platforms.Clear();
        platforms.Add(new(new PointF(100, 400)));
        startPlatformPosY = 400;
        GenerateStartSequence();
        engine = new Engine(platforms);
        player = new Player();
    }

    public static bool IsEnd() => player.GetPositionY() >= platforms[0].GetPositionY() + 200;

    public static void Update()
    {
        engine.CalculatePhysics(player);
        FollowPlayer();
    }

    public static void AddPlatform(PointF position) => platforms.Add(new Platform(position));

    public static void GenerateStartSequence()
    {
        Random r = new Random();
        for (int i = 0; i < 10; i++)
        {
            int x = r.Next(0, 270);
            int y = r.Next(50, 60);
            startPlatformPosY -= y;
            var position = new PointF(x, startPlatformPosY);
            var platform = new Platform(position);
            platforms.Add(platform);
        }
    }

    public static void DrawPlatforms(Graphics g)
    {
        foreach (var platform in platforms)
        {
            platform.DrawSprite(g);
        }
    }

    public static void DrawPlayer(Graphics g) => player.DrawSprite(g);

    public static void DontMove() => engine.dx = 0;
    public static void MoveLeft() => engine.dx = -6;
    public static void MoveRight() => engine.dx = 6;

    public static void GenerateRandomPlatform()
    {
        Random r = new Random();
        int x = r.Next(0, 270);
        PointF position = new PointF(x, startPlatformPosY);
        Platform platform = new Platform(position);
        platforms.Add(platform);
    }

    public static void ClearPlatforms()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].Transform.Position.Y >= 700)
                platforms.RemoveAt(i);
        }
    }

    private static void FollowPlayer()
    {
        int offset = 400 - (int)player.GetPositionY();
        player.Transform.Position.Y += offset;

        foreach (var platform in platforms)
        {
            platform.Transform.Position.Y += offset;
        }

    }

}

