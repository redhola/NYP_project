using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool GameIsOver;

    public GameObject gameOverUI;

    private void Start()
    {
        GameIsOver = false;
    }
    void Update()
    {
        if (GameIsOver)
            EndGame();

        if (Input.GetKeyDown("e"))
        {
            EndGame();
        }

     if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    public void EndGame() // restart pause vs k�s�mlar� eklenecek
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    
}
