using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    public GameObject winPanel;
    public Animator playerAnimator;
    public AudioSource victorySound;
    public ParticleSystem confettiEffect;

    void OnEnable()
    {
        CollectableControl.OnCoinCountUpdated += CheckWinCondition;
    }

    void OnDisable()
    {
        CollectableControl.OnCoinCountUpdated -= CheckWinCondition;
    }

    void CheckWinCondition(int coins)
    {
        if (coins >= 50 && !GameState.IsGameEnded)
        {
            GameState.EndGame();
            SceneManager.LoadScene("WinScene");
            // ActivateWinState();
        }
    }

    // void ActivateWinState()
    // {
    //     // Используем FindAnyObjectByType вместо устаревшего FindObjectOfType
    //     var playerMove = FindAnyObjectByType<PlayerMove>();
    //     if (playerMove != null) playerMove.enabled = false;

    //     var levelGenerator = FindAnyObjectByType<GenerateLevel>();
    //     if (levelGenerator != null) levelGenerator.enabled = false;

    //     playerAnimator.Play("VictoryDance");
    //     winPanel.SetActive(true);
    //     victorySound.Play();
    //     confettiEffect.Play();
    // }

    public void RestartGame()
    {
        CollectableControl.coinCount = 0;
        GameState.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}