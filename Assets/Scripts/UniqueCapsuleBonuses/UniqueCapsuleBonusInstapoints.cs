using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueCapsuleBonusInstapoints : MonoBehaviour
{
    public static UniqueCapsuleBonusInstapoints UniqueCapsuleBonusInstapointsInstance;

    public PlayerCollision playerCollision;
    public GameManager gameManager;

    public int amountToAddUponUniqueCapsule;
    
    private void Awake()
    {
        if (UniqueCapsuleBonusInstapointsInstance == null)
        {
            UniqueCapsuleBonusInstapointsInstance = this;
        }
    }

    public void AddPoints()
    {
        amountToAddUponUniqueCapsule = gameManager.currentLevel * 2;
        playerCollision.capsulesCollected += amountToAddUponUniqueCapsule;
    }
}
