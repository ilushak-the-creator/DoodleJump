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

    private static Physics physics = new Physics();
    private static Player player = new Player();

    public static void AddScore(int size) => score += size;
    public static int GetScore() => score;
    public static void ResetScore() => score = 0;

    public static void RestartGame()
    {
        ResetScore();
        platforms.Clear();
        startPlatformPosY = 400;
        GenerateStartSequence();
        physics = new Physics();
        player = new Player();
    }

    public static bool IsEnd() => player.Transform.Position.Y >= platforms.First().Transform.Position.Y + 200;

    public static void Update()
    {
        physics.CalculatePhysics(player, platforms);
        FollowPlayer();
        MovePlayerThrowWalls();
    }

    public static void AddPlatform(PointF position) => platforms.Add(new Platform(position));

    public static void GenerateStartSequence()
    {
        platforms.Add(new(new PointF(100, 400)));
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

    public static void GenerateRandomPlatform()
    {
        Random r = new Random();
        int x = r.Next(0, 270);
        PointF position = new PointF(x, startPlatformPosY);
        Platform platform = new Platform(position);
        platforms.Add(platform);
    }
    public static void DrawPlatforms(Graphics g)
    {
        foreach (var platform in platforms)
        {
            platform.DrawSprite(g);
        }
    }

    public static void DrawPlayer(Graphics g) => player.DrawSprite(g);

    public static void DontMove() => player.DontMove();
    public static void MoveLeft() => player.MoveLeft();
    public static void MoveRight() => player.MoveRight();

    public static void ClearPlatforms()
    {
        for (int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].Transform.Position.Y >= 700)
            {
                platforms.RemoveAt(i);
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
    }

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

}

