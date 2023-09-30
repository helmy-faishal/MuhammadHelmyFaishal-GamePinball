using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public GameObject bumperVFXPrefabs;
    public GameObject switchVFXPrefabs;
    public static FXManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void PlayVFX(Vector3 position,Color color, bool isBumper = true)
    {
        GameObject prefabs = isBumper ? bumperVFXPrefabs : switchVFXPrefabs;
        GameObject particle = Instantiate(prefabs,position, Quaternion.identity);
        particle.GetComponent<ParticleFXController>().SetParticleColor(color);
    }
}
