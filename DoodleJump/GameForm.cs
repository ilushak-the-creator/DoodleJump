namespace DoodleJump;

public partial class GameForm : Form
{
    public System.Windows.Forms.Timer timer;

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
        Game.Restart();
    }

    private void OnKeyboardUp(object? sender, KeyEventArgs e)
    {
        Game.PlayerDontMove();
    }

    private void OnKeyboardPressed(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
        {
            Game.MovePlayerRight();
        }
        if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
        {
            Game.MovePlayerLeft();
        }
        if (e.KeyCode == Keys.Space)
        {
            Game.PlayerShoot();
        }
    }

    private void Update(object? sender, EventArgs e)
    {
        Text = "Score - " + Game.GetScore();

        if (Game.IsEnd())
        {
            Init();
        }
        Game.Update();
        Invalidate();
    }



    private void OnRepaint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;

        Game.DrawGraphics(g);
    }

    private void OnLoad(object? sender, EventArgs e)
    {
        DoubleBuffered = true;
    }
}