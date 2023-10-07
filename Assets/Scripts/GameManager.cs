using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text scoreUI;
    public int score = 0;
    public Image launcherIndicator;
    public List<Image> chanceList;
    int numberOfChance = 0;

    [Header("Game Over")]
    public TMP_Text gameOverText;
    public float gameOverDelay = 2f;
    public bool isGameOver = false;

    [Header("Ball")]
    public GameObject ballPrefabs;
    public Transform ballSpawner;
    public float respawnDelay = 2f;

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        numberOfChance = chanceList.Count;
        SetScoreText();
        SetLauncherIndicator(0f);
        RespawnBall(false);
        gameOverText.gameObject.SetActive(false);
    }

    public void SetScoreText()
    {
        scoreUI.text = $"Score: {score}";
    }

    public void AddScore(int score) 
    {
        this.score += score;
        SetScoreText();
    }

    public void SubstractScore(int score)
    {
        this.score = Mathf.Max(0, this.score - score);
        SetScoreText();
    }

    public void RespawnBall(bool useDelay=true)
    {
        float delay = useDelay ? respawnDelay : 0f;
        StartCoroutine(RespawnBallCoroutine(delay));
    }

    IEnumerator RespawnBallCoroutine(float delay)
    {
        yield return new WaitForSeconds(delay);
        Instantiate(ballPrefabs, ballSpawner.position, Quaternion.identity);
    }

    public void SetLauncherIndicator(float power)
    {
        launcherIndicator.fillAmount = power;
    }

    public void DecreaseChance()
    {
        chanceList[numberOfChance - 1].color = Color.black;
        numberOfChance -= 1;

        if (numberOfChance <= 0)
        {
            GameOver(); 
        }

    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        gameOverText.gameObject.SetActive(true);
        isGameOver = true;
        StartCoroutine(MoveToMainMenuCoroutine());
    }

    IEnumerator MoveToMainMenuCoroutine()
    {
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene("Main Menu");
    }
}
