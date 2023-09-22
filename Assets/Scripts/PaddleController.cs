using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode keyPress = KeyCode.Z;
    public HingeJoint hinge;
    public float targetPressed;
    public float targetReleased;

    private void Awake()
    {
        hinge = GetComponent<HingeJoint>();
        targetPressed = hinge.limits.max;
        targetReleased = hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
    }

    void MovePaddle()
    {
        JointSpring jointSpring = hinge.spring;

        jointSpring.targetPosition = targetReleased;
        if (Input.GetKey(keyPress))
        {
            jointSpring.targetPosition = targetPressed;
        }

        hinge.spring = jointSpring;
    }
}
