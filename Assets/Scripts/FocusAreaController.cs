using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusAreaController : MonoBehaviour
{
    public Camera mainCamera;
    public float moveTime = 3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            
            mainCamera.GetComponent<CameraController>().MoveToFocus(other.transform,moveTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            mainCamera.GetComponent<CameraController>().BackToDefault(moveTime);
        }
    }
}
