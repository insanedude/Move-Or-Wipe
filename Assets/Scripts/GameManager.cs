using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager GameManagerInstance;

    public ChangeMaterialWhenLevelUp changeMaterialWhenLevelUp;
    public GamePausing gamePausing;
    public ProgressBarController progressBarController;
    public PlayerCollision playerCollision;

    private bool isPressed = false;
    
    public int amountOfCapsules;
    public int amountToNextLevel;
    public int currentLevel;
    public float basetimeToSpawn;
    public float newLevelTimeAddition;
    public int randomFloorGetStatically;

    public Canvas canvasSettings;
    public AudioSource audioSource;


    void Awake()
    {
        if (GameManagerInstance == null)
        {
            GameManagerInstance = this;
        }
        Time.timeScale = 1;
        changeMaterialWhenLevelUp.ChangeFloor();
        audioSource.Play();
        progressBarController.SetFillAmount(amountToNextLevel);
        Debug.Log(StartAfterGuide.InputedUsername);
    }

    private void Start()
    {
        audioSource.volume = PlayerPrefs.GetFloat("musicVolume");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && canvasSettings.isActiveAndEnabled == false)
        {
            gamePausing.TogglePause();
        }

        if (Input.GetKey(KeyCode.H) && Input.GetKeyDown(KeyCode.G))
        {
            isPressed = !isPressed;
            if (isPressed)
            {
                CapsuleSpawner.CapsuleSpawnerInstance.maxAmountOfCapsulesOnField += 1000;
            }
            else
            {
                CapsuleSpawner.CapsuleSpawnerInstance.maxAmountOfCapsulesOnField -= 1000;
            }
        }
        WinCondition();
    }

    public void LevelCompletion()
    {
        progressBarController.ResetFilling();
        CapsuleSpawner.CapsuleSpawnerInstance.availableToSpawn = false;
        currentLevel += 1;
        randomFloorGetStatically += 1;
        amountToNextLevel += currentLevel + Random.Range(0, 3);
        RandomproofMaterialChanger();
        if (currentLevel % 5 == 1)
        {
            CapsuleSpawner.CapsuleSpawnerInstance.maxAmountOfCapsulesOnField += 1;
        }
        progressBarController.SetFillAmount(amountToNextLevel);
        if (playerCollision.backupCapsulesIfOverflow > 0)
        {
            for (int amountOfOverflow = 0; amountOfOverflow < playerCollision.backupCapsulesIfOverflow; amountOfOverflow++)
            {
                progressBarController.CollectItem();
            }
        }
        NextLevel();
    }

    public void RandomproofMaterialChanger()
    {
        var randomFloorGetRandomly = Random.Range(0, 4);
        if (randomFloorGetRandomly == 0)
        {
            changeMaterialWhenLevelUp.ChangeFloor();
            randomFloorGetStatically = 0;
        }
        if (randomFloorGetStatically == 5)
        {
            changeMaterialWhenLevelUp.ChangeFloor();
            randomFloorGetStatically = 0;
        }
    }

    public void WinCondition()
    {
        if (playerCollision.capsulesCollected >= amountToNextLevel)
        {
            LevelCompletion();
        }
    }

    public void NextLevel()
    {
        newLevelTimeAddition += 0.25f * (currentLevel - 1);
        CapsuleSpawner.CapsuleSpawnerInstance.availableToSpawn = true;
        CapsuleSpawner.CapsuleSpawnerInstance.timeToSpawn = basetimeToSpawn;
        PlayerCollision.PlayerCollisionInstance.capsulesCollected = 0;
        PlayerCollision.PlayerCollisionInstance.capsulesCollected +=
            PlayerCollision.PlayerCollisionInstance.backupCapsulesIfOverflow;
        PlayerCollision.PlayerCollisionInstance.backupCapsulesIfOverflow = 0;
    }
}