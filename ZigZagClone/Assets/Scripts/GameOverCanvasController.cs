using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvasController : MonoBehaviour
{
    [SerializeField]
    private Text gameOverScore;
    [SerializeField]
    private Text gameOverHighScore;

    private void OnEnable()
    {
        gameOverScore.text = "Score : " + GameManager.instance.Score.ToString();
        gameOverHighScore.text = "High score : " + PlayerPrefs.GetInt("High Score").ToString();
    }

}