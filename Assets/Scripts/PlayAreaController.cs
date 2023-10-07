using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAreaController : MonoBehaviour
{
    public int penaltyScore = 5;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Bola Keluar");
            Destroy(other.gameObject);
            GameManager.instance?.RespawnBall(true);
            GameManager.instance?.SubstractScore(penaltyScore);
        }
        
    }
}
