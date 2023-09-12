using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public float multiplier = 2f;
    public Color color;
    private Renderer render;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Rigidbody ball = collision.collider.gameObject.GetComponent<Rigidbody>();
            ball.velocity *= multiplier;
        }
    }
}
