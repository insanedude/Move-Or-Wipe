using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StartAfterGuide : MonoBehaviour
{
    public static StartAfterGuide StartAfterGuideInstance;
    public TMP_InputField inputFieldUsername;
    public static string InputedUsername;

    private void Awake()
    {
        if (StartAfterGuideInstance == null)
        {
            StartAfterGuideInstance = this;
        }
    }

    void Start()
    {
        if (inputFieldUsername == null)
        {
            inputFieldUsername = GameObject.Find("UsernameInputField").GetComponent<TMP_InputField>();
        }
    }
    public void ButtonStartGame()
    {
        if (inputFieldUsername.text.Length <= 12)
        {
            if (inputFieldUsername.text != "" )
            {
                InputedUsername = inputFieldUsername.text;
                if (AudioListener.pause)
                {
                    AudioListener.pause = false;
                }
                SceneManager.LoadScene(2);
            }
            else
            {
                Debug.Log("inputfield is empty");
            }
        }
        else
        {
            inputFieldUsername.text = "";
            Debug.Log("inputfield is too long");
        }
    }
}
