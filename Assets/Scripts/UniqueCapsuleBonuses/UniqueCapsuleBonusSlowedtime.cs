using System;
using System.Collections;
using UnityEngine;

public class UniqueCapsuleBonusSlowedTime : MonoBehaviour
{
    public static UniqueCapsuleBonusSlowedTime UniqueCapsuleBonusSlowedTimeInstance;

    public CapsuleSpawner capsuleSpawner;
    
    public int bonusDurationTimeSlowedtime;

    private void Awake()
    {
        if (UniqueCapsuleBonusSlowedTimeInstance == null)
        {
            UniqueCapsuleBonusSlowedTimeInstance = this;
        }
    }
    
    public IEnumerator SlowingTime()
    {
        capsuleSpawner.removeTimeToSpawnNormal /= 2;
        capsuleSpawner.removeTimeToSpawnBonusTime /= 2;
        capsuleSpawner.removeBonusTime /= 2;
        float elapsedTime = 0f;
        while (elapsedTime < bonusDurationTimeSlowedtime)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        capsuleSpawner.removeTimeToSpawnNormal *= 2;
        capsuleSpawner.removeTimeToSpawnBonusTime *= 2;
        capsuleSpawner.removeBonusTime *= 2;
        // capsuleSpawner.removeTimeToSpawnNormal = (float)Math.Round(capsuleSpawner.removeTimeToSpawnNormal, 3);
        // capsuleSpawner.removeTimeToSpawnBonusTime = (float)Math.Round(capsuleSpawner.removeTimeToSpawnBonusTime, 2);
        // capsuleSpawner.removeBonusTime = (float)Math.Round(capsuleSpawner.removeBonusTime, 1);
    }
}