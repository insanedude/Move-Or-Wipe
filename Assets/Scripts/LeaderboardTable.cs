using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderboardTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<LeaderboardEntry> LeaderboardEntryList;
    private List<Transform> leaderboardEntryTransformList;

    private void Awake()
    {
        entryContainer = transform.Find("LeaderboardEntryContainer");
        entryTemplate = entryContainer.Find("LeaderboardEntryTemplate");
        entryTemplate.gameObject.SetActive(false);
        
        string jsonString = PlayerPrefs.GetString("leaderboardTable");
        Leaderboards leaderboards = JsonUtility.FromJson<Leaderboards>(jsonString);
        
        for (int i = 0; i < leaderboards.LeaderboardEntryList.Count; i++)
        {
            for (int j = i + 1; j < leaderboards.LeaderboardEntryList.Count; j++)
            {
                if (leaderboards.LeaderboardEntryList[j].score > leaderboards.LeaderboardEntryList[i].score)
                {
                    (leaderboards.LeaderboardEntryList[i], leaderboards.LeaderboardEntryList[j]) 
                        = (leaderboards.LeaderboardEntryList[j], leaderboards.LeaderboardEntryList[i]);
                }
            }
        }
        leaderboardEntryTransformList = new List<Transform>();
        foreach (LeaderboardEntry leaderboardEntry in leaderboards.LeaderboardEntryList)
        {
            CreateLeaderboardEntryTransform(leaderboardEntry, entryContainer, leaderboardEntryTransformList);
        }
    }

    private void CreateLeaderboardEntryTransform(LeaderboardEntry leaderboardEntry, Transform container, 
        List<Transform> transformList)
    {
        float templateHeight = 40f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        entryTransform.Find("TextShowPosition").GetComponent<TMP_Text>().text = $"{transformList.Count + 1}";

        entryTransform.Find("TextShowUsername").GetComponent<TMP_Text>().text = leaderboardEntry.name;

        entryTransform.Find("TextShowScore").GetComponent<TMP_Text>().text = leaderboardEntry.score.ToString();
        transformList.Add(entryTransform);
    }

    public static void AddLeaderboardEntry(string username, int score)
    {
        LeaderboardEntry leaderboardEntry = new LeaderboardEntry{ name = username, score = score };
        
        string jsonString = PlayerPrefs.GetString("leaderboardTable", "{}");
        Leaderboards leaderboards = JsonUtility.FromJson<Leaderboards>(jsonString) ?? new Leaderboards { LeaderboardEntryList = new List<LeaderboardEntry>() };        
        leaderboards.LeaderboardEntryList.Add(leaderboardEntry);
        string json = JsonUtility.ToJson(leaderboards);
        PlayerPrefs.SetString("leaderboardTable", json);
        PlayerPrefs.Save();
    }
    
    private class Leaderboards
    {
        public List<LeaderboardEntry> LeaderboardEntryList;
    }

    [Serializable] private class LeaderboardEntry
    {
        public int score;
        public string name;
    }

    public void ButtonExitFromLeaderboard()
    {
        SceneManager.LoadScene(0);
    }
}