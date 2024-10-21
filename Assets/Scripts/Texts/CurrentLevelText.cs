using TMPro;
using UnityEngine;

public class CurrentLevelText : MonoBehaviour
{
    public TextMeshProUGUI currentLevelText;
    public int currentLevel;

    void Update()
    {
        if (GameManager.GameManagerInstance != null)
        {
            currentLevel = GameManager.GameManagerInstance.currentLevel;
            if (currentLevelText != null)
            {
                currentLevelText.text = $"Рівень № {currentLevel}";
            }
            else
            {
                Debug.LogWarning("CurrentLevelText is not assigned.");
            }
        }
        else
        {
            Debug.LogWarning("GameManagerInstance is not assigned or not initialized.");
        }
    }
}