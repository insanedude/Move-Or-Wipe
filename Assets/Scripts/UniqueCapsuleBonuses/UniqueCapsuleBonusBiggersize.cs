using System;
using System.Collections;
using UnityEngine;

public class UniqueCapsuleBonusBiggersize : MonoBehaviour
{
    public static UniqueCapsuleBonusBiggersize UniqueCapsuleBonusBiggersizeInstance;
    
    public Transform characterToTransform;
    public int bonusDurationTimeBiggersize;

    private void Awake()
    {
        if (UniqueCapsuleBonusBiggersizeInstance == null)
        {
            UniqueCapsuleBonusBiggersizeInstance = this;
        }
    }
    
    public IEnumerator MakeCharacterBigger()
    {
        float elapsedTime = 0f;
        while (elapsedTime < bonusDurationTimeBiggersize)
        {
            characterToTransform.transform.localScale = new Vector3(0.25f, 10, 0.25f);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        characterToTransform.transform.localScale = new Vector3(0.05f, 5, 0.05f);
    }
}
