using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJump;

public static class Game
{
    public static List<Platform> Platforms = new();
    public static int StartPlatformPosY = 400;
    public static int Score = 0;

    public static void AddPlatform(PointF position) => Platforms.Add(new Platform(position));

    public static void GenerateStartSequence()
    {
        Random r = new Random();
        for (int i = 0; i < 10; i++)
        {
            int x = r.Next(0, 270);
            int y = r.Next(50, 60);
            StartPlatformPosY -= y;
            var position = new PointF(x, StartPlatformPosY);
            var platform = new Platform(position);
            Platforms.Add(platform);
        }
    }

    public static void GenerateRandomPlatform()
    {
        
        Random r = new Random();
        int x = r.Next(0, 270);
        PointF position = new PointF(x, StartPlatformPosY);
        Platform platform = new Platform(position);
        Platforms.Add(platform);
    }

    public static void ClearPlatforms()
    {
        for (int i = 0; i < Platforms.Count; i++)
        {
            if (Platforms[i].Transform.Position.Y >= 700)
                Platforms.RemoveAt(i);
        }
       
    }
}

