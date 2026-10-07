using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public GameObject scoreText;
    public Transform restartButton;
    public GameObject gameOverPanel;
    public GameObject gameOverScore;

    public void GameStart()
    {
        // hide gameover panel
        gameOverPanel.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
        gameOverScore.GetComponent<TextMeshProUGUI>().text = "Score: " + score.ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        scoreText.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    public void GameRestart()
    {
        gameOverPanel.SetActive(false);
        scoreText.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
}
