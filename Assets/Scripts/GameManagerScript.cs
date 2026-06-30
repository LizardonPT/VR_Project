using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript singleton;
    public GameObject gameOverText;
    public GameObject youWinText;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        singleton = this;
        gameOverText.SetActive(false);
        youWinText.SetActive(false);
    }

    // Update is called once per frame
    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverText.SetActive(true);
        StartCoroutine(ResetScene());
    }

    public IEnumerator ResetScene()
    {
        yield return new WaitForSecondsRealtime(3);
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void YouWin()
    {
        Time.timeScale = 0;
        youWinText.SetActive(true);
        StartCoroutine(ResetScene());
    }
}
