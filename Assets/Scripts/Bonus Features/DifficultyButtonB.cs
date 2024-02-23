using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonB : MonoBehaviour
{
    private Button button;
    private GameManagerB gameManager;
    public GameObject titleScreen;

    public int difficulty;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerB>();

        button.onClick.AddListener(SetDifficulty);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetDifficulty()
    {
        gameManager.StartGame(difficulty,lives);
        titleScreen.SetActive(false);
    }
}
