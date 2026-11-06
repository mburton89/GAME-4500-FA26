using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public FPSController fpsController;
    public Cannon cannon;

    public GameObject gameOverOverlay;
    public GameObject inventoryOverlay;

    public TextMeshProUGUI ammoText;

    public bool isPaused;

    public Button buttonToAutoSelect;

    private void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void GameOver()
    {
        //Disable all controls
        fpsController.enabled = false;
        cannon.enabled = false;

        //Show Game Over Overlay with button
        gameOverOverlay.SetActive(true);

        //Bonus: Drop Camera

        //Unlock Cursor

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        inventoryOverlay.SetActive(true);
        fpsController.enabled = false;
        cannon.enabled = false;

        buttonToAutoSelect.Select();

        Time.timeScale = 0;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        inventoryOverlay.SetActive(false);
        fpsController.enabled = true;
        cannon.enabled = true;

        Time.timeScale = 1;
        isPaused = false;
    }
}
