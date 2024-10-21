using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSettingsButtonFunc : MonoBehaviour
{
    public GamePausing gamePausing;
    public GameSettings gameSettings;

    public void ButtonContinue()
    {
        gameSettings.settingsMenuUI.SetActive(false);
        gamePausing.pauseMenuUI.SetActive(true);
    }
}
