using UnityEngine;

public static class GameState
{
    public static bool IsGameEnded { get; private set; }

    public static void EndGame()
    {
        IsGameEnded = true;
        Time.timeScale = 0f;
    }

    public static void ResetGame()
    {
        IsGameEnded = false;
        Time.timeScale = 1f;
    }
}