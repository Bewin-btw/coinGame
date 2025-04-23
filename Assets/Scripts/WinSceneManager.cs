using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour
{
    [Header("References")]
    public GameObject winMenu;
    public Animator playerAnimator;
    public AudioSource victoryMusic;
    public ParticleSystem[] fireworks;

    void Start()
    {
        Time.timeScale = 1f;
        winMenu.SetActive(true);

        foreach (var firework in fireworks)
        {
            firework.gameObject.SetActive(true);
            firework.Play();
        }

        playerAnimator.Rebind(); 
        playerAnimator.Update(0.1f); 
        playerAnimator.Play("WinningAnimation", 0, 0f);

        winMenu.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
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