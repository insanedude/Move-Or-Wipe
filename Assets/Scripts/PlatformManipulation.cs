using System;
using UnityEngine;
using UnityEngine.Video;

public class PlatformManipulation : MonoBehaviour
{
    public static PlatformManipulation PlatformManipulationInstance;
    public MusicRandomizer musicRandomizer;
    public GameObject mainPlatform;
    public VideoPlayer videoPlayer;

    void Awake()
    {
        if (PlatformManipulationInstance == null)
        {
            PlatformManipulationInstance = this;
        }
        GetPlatformSize();
        GetPlatformPosition();
    }

    public Vector3 GetPlatformSize()
    {
        var renderer = mainPlatform.GetComponent<Renderer>();
        return renderer.bounds.size;
    }

    public Vector3 GetPlatformPosition()
    {
        var renderer = mainPlatform.GetComponent<Renderer>();
        return renderer.transform.position;
    }

    public void CheckMusicAndPlayVideo()
    {
        if (musicRandomizer.currentAudioClip == musicRandomizer.specificMusicClip)
        {
            videoPlayer.Play();
        }
    }

    public void StopVideo()
    {
        Debug.Log("pedro stopped");
        videoPlayer.Stop();
    }
}