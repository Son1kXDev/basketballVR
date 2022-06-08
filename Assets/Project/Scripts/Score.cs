using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int score;

    private void Start() => DisplayText();

    private void Update()
    {
        if (Application.loadedLevelName == "Game")
            if (score >= 33)
            {
                SceneManager.LoadScene("GameOver");
                JSONController.instance.isSave = true;
            }
    }

    private void DisplayText() => scoreText.text = "Игрок: " + score.ToString();

    public void AddScore()
    {
        if (score < 30) { score += 3; DisplayText(); }
        else { score += 1; DisplayText(); }
    }
}