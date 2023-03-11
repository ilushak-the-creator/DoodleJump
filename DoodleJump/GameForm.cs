namespace DoodleJump;

public partial class GameForm : Form
{
    public Player player;
    public System.Windows.Forms.Timer timer;
    public Engine engine;


    public GameForm()
    {
        Init();
        InitializeComponent();
        timer = new System.Windows.Forms.Timer();
        timer.Interval = 15;
        timer.Tick += new EventHandler(Update);
        timer.Start();
        KeyDown += new KeyEventHandler(OnKeyboardPressed);
        KeyUp += new KeyEventHandler(OnKeyboardUp);
        BackgroundImage = Resource1.back;
        Height = 600;
        Width = 330;
        Paint += new PaintEventHandler(OnRepaint);
    }

    public void Init()
    {
        Game.AddPlatform(new(100, 400));
        Game.Score = 0;
        Game.StartPlatformPosY = 400;
        
        Game.GenerateStartSequence();
        player = new Player();
        engine = new Engine();
    }

    private void OnKeyboardUp(object sender, KeyEventArgs e)
    {
        engine.dx = 0;
    }

    private void OnKeyboardPressed(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right) 
        {
            engine.dx = 6;
        }
        if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left) 
        {
            engine.dx = -6;
        }
    }

    private void Update(object sender, EventArgs e)
    {
        Text = "Score - " + Game.Score;

        if (player.GetPositionY() >= Game.Platforms.First().GetPositionY() + 200)
        {
            Game.Platforms.Clear();
            Init();

        }
        engine.CalculatePhysics(player);
        FollowPlayer();


        Invalidate();
    }
     
    public void FollowPlayer()
    {
        int offset = 400 - (int)player.GetPositionY();
        player.Transform.Position.Y += offset;

        foreach(var platform in Game.Platforms)
        {
            platform.Transform.Position.Y += offset;
        }

    }

    private void OnRepaint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;

        if (Game.Platforms.Count > 0)
        {
            foreach(var platform in Game.Platforms)
            {
                platform.DrawSprite(g);
            }
        }
        player.DrawSprite(g);
    }

    private void OnLoad(object sender, EventArgs e)
    {
        DoubleBuffered = true;

    }
}