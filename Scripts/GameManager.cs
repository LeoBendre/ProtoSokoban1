using Godot;
using System;

public partial class GameManager : Node2D
{
    [Export] private Button restart;
    [Export] private Label wonText;
    public static int cellSize = 64;
    private static GameManager instance;


    private GameManager() { }

    public static GameManager GetInstance()
    {
        return instance ??= new GameManager();
    }

    public override void _Ready()
    {
        if (instance != null)
        {
            QueueFree();
            return;
        }

        instance = this;

        restart.Pressed += () => GetTree().ReloadCurrentScene();
    }

    private bool won;

    public override void _Process(double pDelta)
    {
        if (!BlocSpot.blocSpots.All(pBlocSpot => pBlocSpot.IsValid()) || won) return;
        GD.Print("GG");
        won = true;
        wonText.Visible = true;
    }

    protected override void Dispose(bool pDisposing)
    {
        instance = null;
        base.Dispose(pDisposing);
    }
}

