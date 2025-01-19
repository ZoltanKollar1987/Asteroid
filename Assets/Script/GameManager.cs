using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreNum;
    [SerializeField] TMP_Text lifeNum;
    [SerializeField] int score;
    [SerializeField] int playerLife;
    
    [SerializeField] GameObject player;
    [SerializeField] Vector2 playerStartPos;
    [SerializeField] AsteroidManager asteroidManager;


    private void Start()
    {  
        StartGame();
    }

    private void Update()
    {
        GameOver();
    }

    void ResetPlayer()
    {
        player.transform.position = playerStartPos;
    }
    void StartGame()
    {
        playerLife = 4;
        lifeNum.text = playerLife.ToString();
        score = 0;
        playerStartPos = player.transform.position;
        
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
            Debug.Log("Game Over!");
        }
        if(asteroidManager.asteroidsList.Count == 0)
        {
            Debug.Log("You Win!!!!");
        }
    }

}
