
using System.Collections;
using System.Linq;
using UnityEngine;

public class MusicRandomizer : MonoBehaviour
{
    public static MusicRandomizer MusicRandomizerInstance;
    
    public PlatformManipulation platformManipulation;

    private static System.Random _rng = new System.Random();
    private Coroutine _playMusicCoroutine;
    public AudioClip[] musicList;
    public AudioClip specificMusicClip;
    public AudioSource musicToPlay;
    public AudioClip[] randomizedListOfMusic;
    public AudioClip currentAudioClip;

    public int currentNumberOfMusic;

    void Awake()
    {
        if (MusicRandomizerInstance == null)
        {
            MusicRandomizerInstance = this;
        }
        randomizedListOfMusic = musicList.OrderBy(audioClip => _rng.Next()).ToArray();
    }

    void Start()
    {
        if (_playMusicCoroutine == null)
        {
            _playMusicCoroutine = StartCoroutine(PlayMusic());
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StopCurrentMusicAndPlayNext();
        }
    }
    IEnumerator PlayMusic()
    {
        while (true)
        { 
            if (platformManipulation.videoPlayer.isPlaying) 
            { 
                platformManipulation.videoPlayer.Stop(); 
            }
            if (currentNumberOfMusic >= musicList.Length)
            {
                currentNumberOfMusic = 0;
                randomizedListOfMusic = musicList;
                randomizedListOfMusic = randomizedListOfMusic.OrderBy(audioClip => _rng.Next()).ToArray();
            }
            currentAudioClip = randomizedListOfMusic[currentNumberOfMusic]; 
            platformManipulation.CheckMusicAndPlayVideo();
            musicToPlay.PlayOneShot(currentAudioClip);
            currentNumberOfMusic += 1;
            yield return new WaitForSeconds(currentAudioClip.length);
            while (musicToPlay.isPlaying)
            {
                yield return null;
            }
        }
    }
    
    void StopCurrentMusicAndPlayNext()
    {
        if (musicToPlay.isPlaying)
        {
            musicToPlay.Stop();
        }

        if (_playMusicCoroutine != null)
        {
            StopCoroutine(_playMusicCoroutine);
        }
        _playMusicCoroutine = StartCoroutine(PlayMusic());
    }
}