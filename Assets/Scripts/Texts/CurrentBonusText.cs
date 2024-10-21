using System;
using TMPro;
using UnityEngine;

public class CurrentBonusText : MonoBehaviour
{
    public TextMeshProUGUI currentBonusTextOnScreen;
    public CurrentBonusText currentBonusTextInstance;

    private void Awake()
    {
        if (currentBonusTextInstance == null)
        {
            currentBonusTextInstance = this;
        }

        currentBonusTextOnScreen.text = "";
    }
}
