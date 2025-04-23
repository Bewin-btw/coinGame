using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject charModel;
    public AudioSource crashThud;
    public GameObject gameOverPanel;

    void OnTriggerEnter(Collider other)
    {
        if (GameState.IsGameEnded) return;

        GetComponent<BoxCollider>().enabled = false;
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        charModel.GetComponent<Animator>().Play("Falling Back Death");
        crashThud.Play();

        StartCoroutine(LoadLoseSceneAfterDelay(1f));
    }

    IEnumerator LoadLoseSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameState.EndGame();
        SceneManager.LoadScene("LoseScene");
    }

    IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(1f);
        gameOverPanel.SetActive(true);
        GameState.EndGame();
    }

    public void RestartGame()
    {
        CollectableControl.coinCount = 0;
        GameState.ResetGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; 
#else
        Application.Quit();
#endif
    }
}
