using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerCollision : MonoBehaviour
{
    public static PlayerCollision PlayerCollisionInstance;

    public AmountOfCapsulesCollectedText amountOfCapsulesCollectedTextToChange;
    public GameManager gameManager;
    public ProgressBarController progressBarController;
    public UniqueCapsuleBonusMagnetism uniqueCapsuleBonusMagnetism;
    public UniqueCapsuleBonusInstapoints uniqueCapsuleBonusInstapoints;
    public UniqueCapsuleBonusBiggersize uniqueCapsuleBonusBiggersize;
    public UniqueCapsuleBonusMultiplier uniqueCapsuleBonusMultiplier;
    public UniqueCapsuleBonusInstalevelup uniqueCapsuleBonusInstalevelup;
    public UniqueCapsuleBonusSlowedTime uniqueCapsuleBonusSlowedTime;
    public CurrentBonusText currentBonusText;
    
    public int capsulesCollected;
    public int allCapsulesCollectedAmount;
    public int backupCapsulesIfOverflow;
    public int normalCapsulePoints;
    public int rareCapsulePoints;
    
    void Awake()
    {
        PlayerCollisionInstance = this;
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.name is "Capsule(Clone)")
        {
            capsulesCollected += normalCapsulePoints;
            progressBarController.OnItemCollected();
            allCapsulesCollectedAmount += normalCapsulePoints;
            CapsuleSpawner.CapsuleSpawnerInstance.amountOfCapsulesNow -= 1;
            Destroy(collisionInfo.collider.gameObject);
        }
        
        if (collisionInfo.collider.name is "Rare Capsule(Clone)")
        {
            capsulesCollected += rareCapsulePoints;
            for (int capsulePoints = 0; capsulePoints < rareCapsulePoints; capsulePoints++)
            {
                progressBarController.OnItemCollected();
            }
            allCapsulesCollectedAmount += rareCapsulePoints;
            if (capsulesCollected > gameManager.amountToNextLevel)
            {
                backupCapsulesIfOverflow = capsulesCollected - gameManager.amountToNextLevel;
            }
            CapsuleSpawner.CapsuleSpawnerInstance.amountOfCapsulesNow -= 1;
            Destroy(collisionInfo.collider.gameObject);
        }

        if (collisionInfo.collider.name is "Unique Capsule(Clone)")
        {
            // int randomizedUniqueCapsuleBonus = 1;
            // int randomizedUniqueCapsuleBonus = Random.Range(0, 5);
            int randomizedUniqueCapsuleBonus = Random.Range(0, 6);
            switch (randomizedUniqueCapsuleBonus)
            {
                case 0:
                    uniqueCapsuleBonusInstapoints.AddPoints();
                    if (capsulesCollected > gameManager.amountToNextLevel)
                    {
                        backupCapsulesIfOverflow = capsulesCollected - gameManager.amountToNextLevel;
                    }
                    currentBonusText.currentBonusTextOnScreen.text = $"+{uniqueCapsuleBonusInstapoints.amountToAddUponUniqueCapsule} очків";
                    break;
                case 1:
                    StartCoroutine(uniqueCapsuleBonusMagnetism.Magnetism());
                    currentBonusText.currentBonusTextOnScreen.text = "магнетизм: " + $"{uniqueCapsuleBonusMagnetism.bonusDurationTimeMagnetism} " + "секунд";
                    break;
                case 2:
                    StartCoroutine(uniqueCapsuleBonusBiggersize.MakeCharacterBigger());
                    currentBonusText.currentBonusTextOnScreen.text = "збільшення персонажа: " + $"{uniqueCapsuleBonusBiggersize.bonusDurationTimeBiggersize} " + "секунд";
                    break;
                case 3:
                    StartCoroutine(uniqueCapsuleBonusMultiplier.PointMultiplication());
                    currentBonusText.currentBonusTextOnScreen.text = "мультиплікатор " + $"x{uniqueCapsuleBonusMultiplier.multiplier}: " +
                                                                     $"{uniqueCapsuleBonusBiggersize.bonusDurationTimeBiggersize}" 
                                                                     + " секунд";
                    break;
                case 4:
                    uniqueCapsuleBonusInstalevelup.InstaLevelUp();
                    currentBonusText.currentBonusTextOnScreen.text = "моментальне підвищення рівня";
                    break;
                case 5:
                    StartCoroutine(uniqueCapsuleBonusSlowedTime.SlowingTime());
                    currentBonusText.currentBonusTextOnScreen.text = "уповільнення часу: " + $"{uniqueCapsuleBonusSlowedTime.bonusDurationTimeSlowedtime} " + "секунд";
                    break;
            }
            Destroy(collisionInfo.collider.gameObject);
        }
    }
}

