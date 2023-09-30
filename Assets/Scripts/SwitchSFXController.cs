using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSFXController : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
        Destroy(gameObject, 1f);
    }
}
