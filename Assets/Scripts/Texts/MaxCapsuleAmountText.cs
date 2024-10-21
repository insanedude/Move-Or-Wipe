using TMPro;
using UnityEngine;

public class MaxCapsuleAmountText : MonoBehaviour
{
    public TextMeshProUGUI maxCapsuleAmountText;
    void Update()
    {
        maxCapsuleAmountText.text = $"Ліміт\nкапсул:\n{CapsuleSpawner.CapsuleSpawnerInstance.maxAmountOfCapsulesOnField}";
    }
}
