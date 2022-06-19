using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameOver = false;
    private float restartTime = 2.0f;
    public void EndGame()
    {
        if(gameOver == false)
        {
            gameOver = true;
            Debug.Log("gameover");
            FindObjectOfType<Scoring>().YouDied();
            Invoke("Restart", restartTime);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
