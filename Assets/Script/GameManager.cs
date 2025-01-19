using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreNum;
    [SerializeField] TMP_Text lifeNum;
    [SerializeField] int score;
    [SerializeField] int playerLife;
    [SerializeField] TMP_Text endGameScoreLose;
    [SerializeField] TMP_Text endGameScoreWin;
    
    [SerializeField] GameObject player;
    [SerializeField] Vector2 playerStartPos;
    [SerializeField] Quaternion playerStartRotation;
    [SerializeField] AsteroidManager asteroidManager;

    [SerializeField] GameObject escapeMenu;
    [SerializeField] GameObject loseMenu;
    [SerializeField] GameObject winMenu;

    [SerializeField] string currentSceneName;

    private void Awake()
    {
        currentSceneName = SceneManager.GetActiveScene().name;
    }

    private void Start()
    {
        
        StartGame();
    }

    private void Update()
    {
        EscapeMenu();
        GameOver();
    }

    void ResetPlayer()
    {
        player.transform.position = playerStartPos;
        player.transform.rotation = playerStartRotation;
    }
    void StartGame()
    {
        playerLife = 4;
        lifeNum.text = playerLife.ToString();
        score = 0;
        playerStartPos = player.transform.position;
        playerStartRotation = player.transform.rotation;
        Time.timeScale = 1;
        
    }

    public void GainScore()
    {
        
        score++;
        scoreNum.text = score.ToString();
    }
    public void LosePlayerLife()
    {
        playerLife--;
        lifeNum.text = playerLife.ToString();
        ResetPlayer();
    }
    public void GameOver()
    {
        if(playerLife == 0)
        {
            Destroy(player);
            LoseMenu();
        }
        if(asteroidManager.asteroidsList.Count == 0)
        {
            WinMenu();
        }
    }

    public void EscapeMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            escapeMenu.SetActive(true);
        }
    }

    public void ReturnToGame()
    {
        Time.timeScale = 1;
        escapeMenu.SetActive(false);
    }

    public void LoseMenu()
    {
        Time.timeScale = 0;
        endGameScoreLose.text = score.ToString();
        loseMenu.SetActive(true);
    }

    public void WinMenu()
    {
        Time.timeScale = 0;
        endGameScoreWin.text = score.ToString();
        winMenu.SetActive(true);
    }

    public void NewGame()
    {      
        SceneManager.LoadScene(currentSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
