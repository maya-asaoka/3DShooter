using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    // singleton class
    public static GameController instance;

    public int coinsToWin;

    private int currentCoins;
    private bool gameOver = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            currentCoins = 0;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver == true && Input.anyKeyDown)
        {
            // reload game
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void CollectCoin()
    {
        // TODO: update coin text
        if (currentCoins == coinsToWin - 1)
        {
            GameWon();
            gameOver = true;
        }
        else 
        {
            currentCoins++;
        }
    }

    void GameWon()
    {
        // TODO
    }

    void GameOver()
    {
        // TODO
    }

}
