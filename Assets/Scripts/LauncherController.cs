using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherController : MonoBehaviour
{
    public float force = 50f;
    public float maxSecond = 2;
    public float power = 0;
    public bool isHold = false;

    void ResetLauncher()
    {
        isHold = false;
        power = 0;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            if (Input.GetKey(KeyCode.Space))
            {
                isHold = true;
                power = Mathf.Clamp(power + Time.deltaTime, 0, maxSecond);
            } else
            {
                if (isHold)
                {
                    float totalForce = power * force;

                    Rigidbody ball = collision.gameObject.GetComponent<Rigidbody>();
                    ball.AddForce(Vector3.forward * totalForce, ForceMode.Impulse);
                    
                    ResetLauncher();
                }
                
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            ResetLauncher();
        }
    }
}
