using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public Button startGameButton;
    public TextMeshProUGUI bestWaveText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
        bestWaveText.SetText("Best: " + PlayerPrefs.GetInt("HighestWave"));
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
