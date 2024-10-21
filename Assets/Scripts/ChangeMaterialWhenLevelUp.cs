using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChangeMaterialWhenLevelUp : MonoBehaviour
{
    public static ChangeMaterialWhenLevelUp ChangeMaterialWhenLevelUpInstance;
    
    public Material[] materialsToChoose;
    public GameObject floorToChange;
    public Renderer floorRenderer;

    private void Awake()
    {
        if (ChangeMaterialWhenLevelUpInstance == null)
        {
            ChangeMaterialWhenLevelUpInstance = this;
        }
        floorRenderer = floorToChange.GetComponent<Renderer>();
    }

    public void ChangeFloor()
    {
        floorRenderer.material = materialsToChoose[Random.Range(0, materialsToChoose.Length)];
    }
}
