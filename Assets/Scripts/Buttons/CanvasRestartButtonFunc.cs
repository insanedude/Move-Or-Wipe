using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasRestartButtonFunc : MonoBehaviour
{
    public GameRestart gameRestart;
    public void ButtonRestartGame()
    {
        gameRestart.restartMenuUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        AudioListener.pause = false;
    }

    public void ButtonQuitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
