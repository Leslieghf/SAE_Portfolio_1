using System;

public class GameManager
{
	public Game Game { get; private set; }

    public GameManager()
    {
        StartNewGame();
    }

    public void StartNewGame()
    {
        Game = new Game();
    }
}
