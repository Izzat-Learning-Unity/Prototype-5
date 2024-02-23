using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerB : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI txtScore;
    public TextMeshProUGUI txtLives;
    public GameObject gameOver;
    public GameObject pauseMenu;

    public Slider volumerSlider;
    public AudioSource playerAudio;

    public bool isGameActive;

    public bool isGamePaused;

    private int score;
    public int lives;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape)&& !isGamePaused&& isGameActive)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            isGamePaused = true;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isGamePaused && isGameActive)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
                isGamePaused = false;
            }
        }
        
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
    public void UpdateLives(int livesToRemove)
    {
        lives += livesToRemove;
        if (lives >= 0)
        {
            txtLives.text = "Lives: " + lives;   
        }
        if (lives < 1)
        {
            GameOver();
        }

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

    public void ChangeVolume()
    {
        playerAudio.volume = volumerSlider.value;
    }

    public void StartGame(int difficulty,int lives)
    {
        isGameActive = true;
        isGamePaused = false;
        spawnRate /= difficulty;

        score = 0;
        UpdateScore(0);
        UpdateLives(lives);
        StartCoroutine(SpawnTargets());


    }


}
