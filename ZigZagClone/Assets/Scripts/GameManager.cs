using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private GameObject gameOverPanel;

    private int score = 0;

    public int Score { get { return score; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        score = 0;
    }

    public void UpdateScore(int collectibleValue)
    {
        score += collectibleValue;
        scoreText.text = "Score : " + score.ToString();

        if(score > PlayerPrefs.GetInt("High Score"))
        {
            PlayerPrefs.SetInt("High Score", score);
        }
    }

    public void GameOver()
    {
        FindObjectOfType<PlayerMovementController>().enabled = false;
        FindObjectOfType<LevelGenerator>().enabled = false;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);      
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}