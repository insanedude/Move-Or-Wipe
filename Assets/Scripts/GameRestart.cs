using TMPro;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    public GameObject restartMenuUI;
    [SerializeField] private TextMeshProUGUI allCapsulesAmount;
    [SerializeField] private TextMeshProUGUI levelUponFailing;
    
    void Start()
    {
        if (restartMenuUI != null)
        {
            restartMenuUI.SetActive(false);
        }
    }
    public void Restart()
    {
        AudioListener.pause = true;
        int capsulesCollected = PlayerCollision.PlayerCollisionInstance.allCapsulesCollectedAmount;
        allCapsulesAmount.text += capsulesCollected;
        levelUponFailing.text += GameManager.GameManagerInstance.currentLevel;
        LeaderboardTable.AddLeaderboardEntry(StartAfterGuide.InputedUsername, capsulesCollected);
        restartMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.GameManagerInstance.newLevelTimeAddition = 0;
        GameManager.GameManagerInstance.currentLevel = 1;
        PlayerCollision.PlayerCollisionInstance.capsulesCollected = 0;
        PlayerCollision.PlayerCollisionInstance.allCapsulesCollectedAmount = 0;
        CapsuleSpawner.CapsuleSpawnerInstance.timeToSpawn = 2.5f;
    }
}
