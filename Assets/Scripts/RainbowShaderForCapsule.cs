using System.Collections;
using UnityEngine;

public class RainbowShaderForCapsule : MonoBehaviour
{
    private Material _mt;
    private Color32[] _colors;
    void Start()
    {
        _mt = transform.GetComponent<MeshRenderer>().material;
        _colors = new Color32[7]
        {
            new (255, 0, 0, 255), //red
            new (255, 165, 0, 255), //orange
            new (255, 255, 0, 255), //yellow
            new (0, 255, 0, 255), //green
            new (0, 0, 255, 255), //blue
            new (75, 0, 130, 255), //indigo
            new (238, 130, 238, 255), //violet
        };
        StartCoroutine(Cycle());
    }
    public IEnumerator Cycle()
    {
        int i = 0;
        while(true)
        {
            for(float interpolant = 0f; interpolant < 1f; interpolant += 0.01f)
            {
                _mt.color = Color.Lerp(_colors[i%7], _colors[(i+1)%7], interpolant);
                yield return null;
            }
            i++;
        }
    }
}