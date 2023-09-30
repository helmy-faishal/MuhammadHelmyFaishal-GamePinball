using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 defaultPosition;
    Transform target;
    public Vector3 offset = new Vector3(0, 3, -1);
    public float followSpeed = 5;

    bool hasTarget { get { return target != null; } }
    bool isMove = false;

    private void Awake()
    {
        defaultPosition = transform.position;
        target = null;
    }

    private void LateUpdate()
    {
        if (hasTarget && !isMove)
        {
            Vector3 targetPosition = target.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void MoveToFocus(Transform toTarget,float moveTime)
    {
        isMove = true;
        StopAllCoroutines();
        StartCoroutine(MoveToFocusCoroutine(toTarget,moveTime,offset));
        target = toTarget;
    }

    public void BackToDefault(float moveTime)
    {
        isMove = true;
        StopAllCoroutines();
        StartCoroutine(MoveToFocusCoroutine(defaultPosition, moveTime, Vector3.zero));
        target = null;
    }

    IEnumerator MoveToFocusCoroutine(Transform targetTransform, float moveTime, Vector3 targetOffset)
    {
        Transform destination = targetTransform;

        float time = 0;
        while (time < moveTime)
        {
            time += Time.deltaTime;
            float smoothing = Mathf.SmoothStep(0, 1, time / moveTime);
            transform.position = Vector3.Lerp(transform.position, destination.position + targetOffset, smoothing);
            yield return new WaitForEndOfFrame();
        }
        isMove = false;
    }

    IEnumerator MoveToFocusCoroutine(Vector3 targetPosition, float moveTime, Vector3 targetOffset)
    {
        Vector3 destination = targetPosition;

        float time = 0;
        while (time < moveTime)
        {
            time += Time.deltaTime;
            float smoothing = Mathf.SmoothStep(0, 1, time / moveTime);
            transform.position = Vector3.Lerp(transform.position, destination + targetOffset, smoothing);
            yield return new WaitForEndOfFrame();
        }
        isMove = false;
    }

}
