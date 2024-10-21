using System;
using System.Collections;
using UnityEngine;

public class UniqueCapsuleBonusMultiplier : MonoBehaviour
{
    public static UniqueCapsuleBonusMultiplier UniqueCapsuleBonusMultiplierInstance;

    public PlayerCollision playerCollision;    
    
    public int bonusDurationTimeMultiplier;
    public int multiplier;

    private void Awake()
    {
        if (UniqueCapsuleBonusMultiplierInstance == null)
        {
            UniqueCapsuleBonusMultiplierInstance = this;
        }
    }
    
    public IEnumerator PointMultiplication()
    {
        playerCollision.normalCapsulePoints *= multiplier;
        playerCollision.rareCapsulePoints *= multiplier;
        float elapsedTime = 0f;
        while (elapsedTime < bonusDurationTimeMultiplier)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        playerCollision.normalCapsulePoints /= multiplier;
        playerCollision.rareCapsulePoints /= multiplier;
    }
}