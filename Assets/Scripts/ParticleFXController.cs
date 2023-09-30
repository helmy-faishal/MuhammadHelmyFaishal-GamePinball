using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFXController : MonoBehaviour
{
    public Material material;
    Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.material = material; 
    }
    void Start()
    {
        Destroy(gameObject,1f);
    }

    public void SetParticleColor(Color color)
    {
        render.material.color = color;
    }
}
