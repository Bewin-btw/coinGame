using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneManager : MonoBehaviour
{
    [Header("References")]
    public GameObject loseMenu; 
    public Animator playerAnimator; 
    public AudioSource defeatMusic; 
    public Light directionalLight; 

    void Start()
    {
        Time.timeScale = 1f; 

        // Проверка анимации
        if (playerAnimator != null)
        {
            playerAnimator.Play("LosingAnimation", 0); 
        }
        else
        {
            Debug.LogError("Player Animator не назначен!");
        }

        if (defeatMusic != null)
        {
            defeatMusic.Play();
        }

        // if (directionalLight != null)
        // {
        //     directionalLight.intensity = 0.3f;
        //     RenderSettings.ambientIntensity = 0.5f;
        // }

        loseMenu.SetActive(true);
    }

    public void RestartGame()
    {
        CollectableControl.coinCount = 0; 
        GameState.ResetGame();
        SceneManager.LoadScene("JungleRun"); 
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