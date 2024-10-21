using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings GameSettingsInstance;
    public GameObject settingsMenuUI;

    void Awake()
    {
        if (GameSettingsInstance == null)
        {
            GameSettingsInstance = this;
        }
    }

    void Start()
    {
        if (settingsMenuUI != null)
        {
            settingsMenuUI.SetActive(false);
        }
    }
}