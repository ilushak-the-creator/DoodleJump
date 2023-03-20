namespace DoodleJump;

public partial class GameForm : Form
{
    private readonly GameManager game;
    public System.Windows.Forms.Timer timer;

    public GameForm(GameManager game)
    {
        this.game = game;

        game.Restart();
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


    private void OnKeyboardUp(object? sender, KeyEventArgs e)
    {
        game.PlayerDontMove();
    }

    private void OnKeyboardPressed(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
        {
            game.MovePlayerRight();
        }
        if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
        {
            game.MovePlayerLeft();
        }
        if (e.KeyCode == Keys.Space)
        {
            game.PlayerShoot();
        }
    }

    private void Update(object? sender, EventArgs e)
    {
        Text = "Score - " + game.Score + " | Max Score: " + game.MaxScore;

        if (game.IsEnd())
        {
            game.Restart();
        }
        game.Update();
        Invalidate();
    }



    private void OnRepaint(object? sender, PaintEventArgs e)
    {
        var g = e.Graphics;

        game.DrawGraphics(g);
    }

    private void OnLoad(object? sender, EventArgs e)
    {
        DoubleBuffered = true;
    }
}