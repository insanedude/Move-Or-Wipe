using System;
using System.Collections;
using UnityEngine;

public class UniqueCapsuleBonusInstalevelup : MonoBehaviour
{
    public static UniqueCapsuleBonusInstalevelup UniqueCapsuleBonusInstalevelupInstance;

    public GameManager gameManager;

    private void Awake()
    {
        if (UniqueCapsuleBonusInstalevelupInstance == null)
        {
            UniqueCapsuleBonusInstalevelupInstance = this;
        }
    }

    public void InstaLevelUp()
    {
        gameManager.LevelCompletion();
    }
}