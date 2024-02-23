using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI txtScore;
    public GameObject gameOver;

    public bool isGameActive;


    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTargets()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int randomIndex = Random.Range(0, targets.Count);

            Instantiate(targets[randomIndex]);


        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        txtScore.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;

        score = 0;
        UpdateScore(0);
        StartCoroutine(SpawnTargets());
    }
}
