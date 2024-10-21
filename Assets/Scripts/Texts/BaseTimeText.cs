using System;
using TMPro;
using UnityEngine;

public class BaseTimeText : MonoBehaviour
{
    public TextMeshProUGUI baseTimeTextOnScreen;
    
    void Update()
    {
        baseTimeTextOnScreen.text = $"Спавн капсули через:\n{CapsuleSpawner.CapsuleSpawnerInstance.timeToSpawn}\nсекунди";
    }
}
