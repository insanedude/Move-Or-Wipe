using System;
using UnityEngine;

public class ProgressBarController : MonoBehaviour
{
    public Renderer[] targetRenderers; // Array of Renderers for multiple 3D objects
    public float fillAmountNow; // Initial fill amount (0-1)
    public float amountStepFill;

    private Material[] _progressBarMaterials;
    private static readonly int Fill = Shader.PropertyToID("_Fill");

    void Start()
    {
        // Initialize materials for all target renderers
        _progressBarMaterials = new Material[targetRenderers.Length];
        for (int i = 0; i < targetRenderers.Length; i++)
        {
            _progressBarMaterials[i] = targetRenderers[i].material;
        }
    }

    void Update()
    {
        // Update the fill amount in all materials
        foreach (Material material in _progressBarMaterials)
        {
            material.SetFloat(Fill, fillAmountNow);
        }
    }

    public void SetFillAmount(float capsuleAmount)
    {
        amountStepFill = (float)Math.Round(1 / capsuleAmount, 3);
    }
    
    public void CollectItem()
    {
        // Increase fill amount when an item is collected
        fillAmountNow += amountStepFill;
        if (fillAmountNow > 1f) fillAmountNow = 1f;
    }
    
    public void OnItemCollected()
    {
        // Find all ProgressBarController instances in the scene and call CollectItem
        ProgressBarController[] progressBars = FindObjectsOfType<ProgressBarController>();
        foreach (ProgressBarController progressBar in progressBars)
        {
            progressBar.CollectItem();
        }
    }

    public void ResetFilling()
    {
        fillAmountNow = 0f;
    }
}