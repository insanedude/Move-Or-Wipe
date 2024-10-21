using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPauseButtonFunc : MonoBehaviour
{
    public GamePausing gamePausing;
    public GameSettings gameSettings;
    public void ButtonResume()
    {
        gamePausing.TogglePause();
    }

    public void ButtonSettings()
    {
        gamePausing.pauseMenuUI.SetActive(false);
        gameSettings.settingsMenuUI.SetActive(true);
    }
        
    public void ButtonQuit()
    {
        SceneManager.LoadScene(0);
        MusicRandomizer.MusicRandomizerInstance.musicToPlay.Stop();
    }
}