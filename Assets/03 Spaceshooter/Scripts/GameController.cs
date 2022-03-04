using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text gameoverText;
    private int Score;


    void Start()
    {
        Score = 0;
       StartCoroutine(SpawnWaves());
    }

    
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void addScore()
    {
        Score++;
        UpdateScore(Score);
    }

    private void UpdateScore(int newScore)
    {
        scoreText.text = "SCORE: " + newScore;
    }

    public void GameOver()
    {
        gameoverText.text = "GAMEOVER\n" + Score;
    }
}
