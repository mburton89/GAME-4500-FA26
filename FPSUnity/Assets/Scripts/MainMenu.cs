using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button startGameButton;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
