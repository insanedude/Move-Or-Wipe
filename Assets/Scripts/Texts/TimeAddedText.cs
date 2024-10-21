using TMPro;
using UnityEngine;

public class TimeAddedText : MonoBehaviour
{
    public TextMeshProUGUI timeAddedText;
    void Update()
    {
        timeAddedText.text = GameManager.GameManagerInstance.newLevelTimeAddition < 0f ? "0" : $"Бонусний час:\n{GameManager.GameManagerInstance.newLevelTimeAddition}";
    }
}
