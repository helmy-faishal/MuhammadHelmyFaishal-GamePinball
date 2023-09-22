using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    public float multiplier = 2f;
    public Color color;
    private Renderer render;
    private Animator animator;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        render.material.color = color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Rigidbody ball = collision.gameObject.GetComponent<Rigidbody>();
            ball.velocity *= multiplier;
            animator.SetTrigger("hit");
        }
    }
}
