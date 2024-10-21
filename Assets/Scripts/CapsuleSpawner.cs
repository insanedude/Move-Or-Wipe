using System;
using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CapsuleSpawner : MonoBehaviour
{
    public static CapsuleSpawner CapsuleSpawnerInstance;

    public GameManager gameManager;
    public GetCharacterPosition getCharacterPosition;
    public PlatformManipulation platformManipulation;
    public GameRestart gameRestart;
    
    public int amountOfCapsulesNow;
    public int maxAmountOfCapsulesOnField;
    public float timeToSpawn;
    public float borderLimitFromSpawningFromWalls;
    public float borderLimitFromSpawningAroundCharacter;
    public bool availableToSpawn;
    public int determinationOfCapsuleType;
    public float removeTimeToSpawnNormal;
    public float removeTimeToSpawnBonusTime;
    public float removeBonusTime;
    
    public GameObject[] objectsToSpawn;
    public Vector3 sizeOfPlatform;
    public Vector3 randomPositionOnPlatform;
    public Vector3 randomCapsuleSpawnPosition;
    

    void Awake()
    {
        if (CapsuleSpawnerInstance == null)
        {
            CapsuleSpawnerInstance = this;
        }
        StartCoroutine(TimedSpawner());
        sizeOfPlatform = platformManipulation.GetPlatformSize();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            CapsuleSpawn();
        }
        if (GameObject.Find("Capsule(Clone)") == null && GameObject.Find("Rare Capsule(Clone)") == null)
        {
            if (timeToSpawn > 1f)
            {
                CapsuleSpawn();
                timeToSpawn -= removeTimeToSpawnBonusTime;
            }
            else
            {
                CapsuleSpawn();
            }
        }
    }

    IEnumerator TimedSpawner()
    {
        while (availableToSpawn)
        {
            CapsuleSpawn();
            yield return new WaitForSeconds(timeToSpawn);
            if (gameManager.newLevelTimeAddition > 0f)
            {
                gameManager.newLevelTimeAddition -= removeBonusTime;
                gameManager.newLevelTimeAddition = (float)Math.Round(gameManager.newLevelTimeAddition, 3);
                timeToSpawn -= removeTimeToSpawnBonusTime;
                timeToSpawn = (float)Math.Round(timeToSpawn, 3);
            }
            else
            {
                if (timeToSpawn >= 1f)
                {
                    timeToSpawn -= removeTimeToSpawnNormal;
                }
            }
        }
    }

    void CapsuleSpawn()
    {
        if (amountOfCapsulesNow >= maxAmountOfCapsulesOnField)
        {
            gameRestart.Restart();
        }
        else
        {
            determinationOfCapsuleType = Random.Range(0, 100);
            randomCapsuleSpawnPosition = GetRandomSpawnPosition();
            if (determinationOfCapsuleType % 20 == 0)
            {
                Instantiate(objectsToSpawn[2], randomCapsuleSpawnPosition, Quaternion.identity); // spawn unique capsule in 1/20 probability
            }
            else if (determinationOfCapsuleType % 6 == 0)
            {
                Instantiate(objectsToSpawn[1], randomCapsuleSpawnPosition, Quaternion.identity); // spawn rare capsule in ~1/6 probability
                amountOfCapsulesNow += 1;
            }
            else
            {
                Instantiate(objectsToSpawn[0], randomCapsuleSpawnPosition, Quaternion.identity); // spawn regular capsule
                amountOfCapsulesNow += 1;
            }
        }
    }
    
    Vector3 GetRandomSpawnPosition()
    {
        var characterPosition = getCharacterPosition.GetCharacterCurrentPosition();
        var platformPosition = platformManipulation.GetPlatformPosition();
        do
        {
            randomPositionOnPlatform = new Vector3(
                Random.Range(platformPosition.x - sizeOfPlatform.x / 2 + borderLimitFromSpawningFromWalls,
                    platformPosition.x + sizeOfPlatform.x / 2 - borderLimitFromSpawningFromWalls + 1),
                platformPosition.y + 2,
                Random.Range(platformPosition.z - sizeOfPlatform.z / 2 + borderLimitFromSpawningFromWalls,
                    platformPosition.z + sizeOfPlatform.z / 2 - borderLimitFromSpawningFromWalls + 1));
        } while (IsWithinExclusionArea(randomPositionOnPlatform, characterPosition));
        return randomPositionOnPlatform;
    }
    
    bool IsWithinExclusionArea(Vector3 capsulePosition, Vector3 characterPositionForExclusion)
    {
        return Mathf.Abs(capsulePosition.x - characterPositionForExclusion.x) <= borderLimitFromSpawningAroundCharacter &&
               Mathf.Abs(capsulePosition.z - characterPositionForExclusion.z) <= borderLimitFromSpawningAroundCharacter;
    }
}