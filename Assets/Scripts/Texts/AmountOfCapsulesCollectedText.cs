using TMPro;
using UnityEngine;

public class AmountOfCapsulesCollectedText : MonoBehaviour
{
    public TextMeshProUGUI amountOfCapsulesText;
    void Update()
    {
        GameManager.GameManagerInstance.amountOfCapsules = PlayerCollision.PlayerCollisionInstance.capsulesCollected;
        amountOfCapsulesText.text = $"Зібрано капсул: {GameManager.GameManagerInstance.amountOfCapsules}" + "/" 
            + GameManager.GameManagerInstance.amountToNextLevel;
    }
}