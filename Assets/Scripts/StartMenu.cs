using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // void Awake()
    // {
    //     PlayerPrefs.SetFloat("musicVolume", 0.25f);
    // }

    public void ButtonStartGuide()
    {
        SceneManager.LoadScene(1);
    }

    public void ButtonCharacterCustomization()
    {
        SceneManager.LoadScene(3);
    }

    public void ButtonLeaderboards()
    {
        SceneManager.LoadScene(4);
    }
    
    public void ButtonQuitGame()
    {
        Application.Quit();
    }
}
