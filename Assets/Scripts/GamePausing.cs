using UnityEngine;

public class GamePausing : MonoBehaviour
{
    public static GamePausing GamePausingInstance;

    public PlatformManipulation platformManipulation;
    public MusicRandomizer musicRandomizer;
    
    public GameObject pauseMenuUI;
    
    bool isPaused;

    void Awake()
    {
        if (GamePausingInstance == null)
        {
            GamePausingInstance = this;
        }
    }

    void Start()
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }
    
    public void TogglePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        AudioListener.pause = true;
        if (musicRandomizer.currentAudioClip == musicRandomizer.specificMusicClip)
        {
            platformManipulation.videoPlayer.Pause();
        }
    }

    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        if (musicRandomizer.currentAudioClip == musicRandomizer.specificMusicClip)
        {
            platformManipulation.videoPlayer.Play();
        }
    }
}