using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueCapsuleBonusMagnetism : MonoBehaviour
{
    public static UniqueCapsuleBonusMagnetism UniqueCapsuleBonusMagnetismInstance;
    
    private List<Rigidbody> _allRigidbodyCapsulesOnField;
    private GameObject[] _capsuleObjects;

    public int bonusDurationTimeMagnetism;
    
    private void Awake()
    {
        if (UniqueCapsuleBonusMagnetismInstance == null)
        {
            UniqueCapsuleBonusMagnetismInstance = this;
        }
    }
    
    private void Start()
    {
        _allRigidbodyCapsulesOnField = new List<Rigidbody>();
    }

    public IEnumerator Magnetism()
    {
        _allRigidbodyCapsulesOnField.Clear();
        GameObject[] capsuleObjects = GameObject.FindGameObjectsWithTag("CapsuleToPull");
        Vector3[] startPositions = new Vector3[capsuleObjects.Length];
        
        for (int i = 0; i < capsuleObjects.Length; i++)
        {
            if (capsuleObjects[i] != null)
            {
                startPositions[i] = capsuleObjects[i].transform.position;
            }
        }

        float elapsedTime = 0f;

        while (elapsedTime < bonusDurationTimeMagnetism)
        {
            for (int i = 0; i < capsuleObjects.Length; i++)
            {
                if (capsuleObjects[i] != null)
                {
                    capsuleObjects[i].transform.position = Vector3.Lerp(
                        startPositions[i],
                        GetCharacterPosition.GetCharacterPositionInstance.GetCharacterCurrentPosition(),
                        0.005f
                    );
                }
            }

            elapsedTime += Time.deltaTime;
            yield return null;

            capsuleObjects = GameObject.FindGameObjectsWithTag("CapsuleToPull");
            startPositions = new Vector3[capsuleObjects.Length];
            for (int i = 0; i < capsuleObjects.Length; i++)
            {
                if (capsuleObjects[i] != null)
                {
                    startPositions[i] = capsuleObjects[i].transform.position;
                }
            }
        }
        
        foreach (GameObject capsule in capsuleObjects)
        {
            if (capsule != null)
            {
                Rigidbody rb = capsule.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }
}