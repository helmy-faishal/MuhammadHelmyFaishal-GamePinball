using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;

    public GameObject sfxBumperPrefabs;
    public GameObject sfxSwitchPrefabs;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bgmAudioSource?.Play();
    }

    public void PlayBumperSFX(Vector3 position)
    {
        Instantiate(sfxBumperPrefabs, position, Quaternion.identity);
    }

    public void PlaySwitchSFX(Vector3 position)
    {
        Instantiate(sfxSwitchPrefabs, position, Quaternion.identity);
    }
}
