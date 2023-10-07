using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseAreaController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            FXManager.instance?.PlayVFX(other.transform.position, Color.black);
            Destroy(other.gameObject);
            GameManager.instance.DecreaseChance();
            if (!GameManager.instance.isGameOver)
            {
                GameManager.instance.RespawnBall(true);
            }
            Debug.Log("Player Lose");
        }
    }
}
