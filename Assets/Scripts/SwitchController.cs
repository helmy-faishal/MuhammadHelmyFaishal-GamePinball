using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{
    public Material onMaterial, offMaterial;
    public Renderer render;

    public int blinkTimes = 2;
    public float blinkInterval = 0.5f;

    public bool isSwitchActive = false;

    public int switchScore = 10;

    private void Awake()
    {
        render = GetComponent<Renderer>();
        render.material = offMaterial;
    }

    private void Start()
    {
        StartCoroutine(StartBlinkCoroutine(blinkTimes, blinkInterval));
    }

    void ChangeSwitchColor(bool active)
    {
        if (active)
        {
            render.material = onMaterial;
            StopAllCoroutines();
        } 
        else
        {
            render.material = offMaterial;
            StartCoroutine(StartBlinkCoroutine(blinkTimes, blinkInterval));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            isSwitchActive = !isSwitchActive;
            ChangeSwitchColor(isSwitchActive);

            // (?.) Cek null untuk Test Scene
            AudioManager.instance?.PlaySwitchSFX(transform.position);

            // Ketika Switch berubah aktif, warna VFX menggunakan warna onMaterial
            Color colorVFX = isSwitchActive? onMaterial.color : offMaterial.color;
            FXManager.instance?.PlayVFX(transform.position,colorVFX,false);

            GameManager.instance?.AddScore(switchScore);
        }
    }

    IEnumerator StartBlinkCoroutine(int times, float interval = 0.5f)
    {
        render.material = offMaterial;
        for (int i = 0; i < times; i++)
        {
            yield return new WaitForSeconds(interval);
            render.material = onMaterial;
            yield return new WaitForSeconds(interval);
            render.material = offMaterial;
        }

        StartCoroutine(StartBlinkCoroutine(times, interval));
    }
}
