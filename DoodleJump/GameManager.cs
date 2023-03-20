using DoodleJump.Extensions;
using DoodleJump.Factories;
using DoodleJump.Interfaces;
using DoodleJump.Models;
using DoodleJump.Models.Monsters;
using DoodleJump.Models.Busters;

namespace DoodleJump;

public class GameManager
{
    // TODO: вынести все цфиры в отдельный класс / файл с константами

    public int Score { get; private set; }
    public int MaxScore { get; private set; }

    private const int startPlatformPositionX = 100;
    private const int startPlatformPosY = 400;

    private Queue<Platform> platforms = new();
    private List<IInteractable> interactables = new();

    private InteractableItemsFactory interactableItemsFactory = new();

    private Physics physics = new Physics();
    private Player player = new Player();

    private Random rand = new Random();


    

    public void Restart()
    {
        MaxScore = WriteFileMaxScore();
        Score = 0;
        platforms.Clear();
        interactables.Clear();
        GenerateStartSequence();
        physics = new Physics();
        player = new Player();
    }

    public bool IsEnd() => player.InteractionModel.Position.Y >= platforms.First().InteractionModel.Position.Y + 200 || !player.IsAlive;

    public void Update()
    {

        physics.CalculatePhysics(player, new List<IEnumerable<IInteractable>> {interactables, platforms });
        FollowPlayer();
        MovePlayerThrowWalls();
        ClearPlatforms();
        ClearInteractables();
        
    }

    public void DrawGraphics(Graphics g)
    {
        foreach(var item in interactables)
        {
            g.DrawImage(item);
        }
        
        foreach(var item in platforms)
        {
            g.DrawImage(item);
        }
        g.DrawImage(player);
    }
    public void PlayerDontMove() => player.Stop();
    public void MovePlayerLeft() => player.SetDirectionLeft();
    public void MovePlayerRight() => player.SetDirectionRight();

    private void GenerateStartSequence()
    {
        platforms.Enqueue(new(new PointF(startPlatformPositionX, startPlatformPosY)));
        for (int i = 0; i < 15; i++)
        {
            int x = rand.Next(0, 270);
            int y = rand.Next(50, 60);

            var position = new PointF(x, platforms.Last().InteractionModel.Position.Y - y);
            var platform = new Platform(position);
            platforms.Enqueue(platform);
            
        }
    }

    private void GenerateRandomPlatform()
    {
        var x = rand.Next(0, 270);
        var y = rand.Next(50, 80);

        var position = new PointF(x, platforms.Last().InteractionModel.Position.Y - y);
        var platform = new Platform(position);

        platforms.Enqueue(platform);

        var item = GetRandomInteractableItem();
        if (item != null)
        {
            PlaceOnPlatform(item, platform);
            interactables.Add(item);
        }

    }
    private void PlaceOnPlatform(IInteractable item, Platform platform) =>
         item.InteractionModel.Position = new PointF(
            platform.InteractionModel.Position.X + platform.InteractionModel.Size.Width / 2 
             - item.InteractionModel.Size.Width / 2,
            platform.InteractionModel.Position.Y - item.InteractionModel.Size.Height);

    private void ClearPlatforms()
    {
        if (!platforms.Any()) return;
        for (var i = 0; i < platforms.Count; i++)
        {
            if (platforms.Peek().InteractionModel.Position.Y >= 650)
            {
                platforms.Dequeue();
                GenerateRandomPlatform();
                Score += 20;
            }
        }
    }

    private void ClearInteractables()
    {
        if (!interactables.Any()) return; 
        for (var i = 0; i < interactables.Count; i++)
        {
            if (interactables.First().InteractionModel.Position.Y >= 650 
                ||  interactables[i].IsTouchedByPlayer)
            {
               // if (interactables[i] is Buster) BoostPlayerByBoosters((Buster)interactables[i]);

                interactables.Remove(interactables.First());
            }
        }
    }

    private void BoostPlayerByBoosters(Buster buster) => buster.UseBuster(player);

    private void FollowPlayer()
    {
        var offset = 400 - (int)player.InteractionModel.Position.Y;
        player.InteractionModel.Position.Y += offset;

        foreach (var platform in platforms)
        {
            platform.InteractionModel.Position.Y += offset;
        }
        foreach(var item in interactables)
        {
            item.InteractionModel.Position.Y += offset;
        }
    }

    private void MovePlayerThrowWalls()
    {
        if (player.InteractionModel.Position.X < -20)
        {
            player.InteractionModel.Position.X = 300;
        }
        if (player.InteractionModel.Position.X > 300)
        {
            player.InteractionModel.Position.X = -20;
        }
    }

    private IInteractable GetRandomInteractableItem() => interactableItemsFactory.CreateRandom();

    public void PlayerShoot()
    {
        player.Shoot();
        foreach (var item in interactables)
        {
            if (item.InteractionModel.Position.Y > 0 && item is Monster)
            {
                interactables.Remove(item);
                break;
            }
        }
    }

    public void KillMonster(Monster monster)
    {
        interactables.Remove(monster);
    }

    private int WriteFileMaxScore()
    {
        var sr = new StreamReader("C:\\Users\\ryaby\\OneDrive\\Рабочий стол\\Контур игра\\DoodleJump\\DoodleJump\\maxScore.txt");
        var maxScore = int.Parse(sr.ReadToEnd());
        sr.Close();
        if (Score > maxScore)
        {
            var sw = new StreamWriter("C:\\Users\\ryaby\\OneDrive\\Рабочий стол\\Контур игра\\DoodleJump\\DoodleJump\\maxScore.txt");
            sw.WriteLine(Score);
            sw.Close();
        }
        return maxScore;
    }
}
