
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public static MenuManager instance;
    public GameObject gameCanvas;
    public GameObject gameOverPanel;
    public TextMeshProUGUI deathText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver(string reason)
    {
        if (reason != null)
        {
            deathText.text = "You died from a lack of... " + reason;
        }
        gameOverPanel.SetActive(true);
        gameCanvas.SetActive(false);
        ScoreManager.instance.StopScore();
        GameManager.instance.StopGame();
    }

}
