using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text highScoreText;
    [SerializeField]
    private GameObject gameOverPanel;

    public int score = 0;

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
    }

    private void LateUpdate()
    {
        score += ((int)PlayerMovementController.playerCurrentPosition.magnitude / 10);
        scoreText.text = "Score : " + score.ToString();
    }


    public void GameOver()
    {
        FindObjectOfType<PlayerMovementController>().enabled = false;
        FindObjectOfType<LevelGenerator>().enabled = false;
        gameOverPanel.SetActive(true);
    }
}