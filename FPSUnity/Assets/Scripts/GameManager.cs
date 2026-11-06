using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public FPSController fpsController;
    public Cannon cannon;

    public GameObject gameOverOverlay;
    public GameObject inventoryOverOverlay;
    public Button buttonToAutoSelect;

    bool gameIsPaused;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
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
        //STEP 1 Disable all Controls
        fpsController.enabled = false;
        cannon.enabled = false;

        //STEP 2 Show Game Over Overlay w Button
        gameOverOverlay.SetActive(true);

        //BONUS Drop Camera

        //STEP 3 Unlock Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    public void PauseGame()
    {
        gameIsPaused = true;
        Cursor.visible = true;
        fpsController.enabled = false;
        cannon.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        inventoryOverOverlay.SetActive(true);
        buttonToAutoSelect.Select();
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        gameIsPaused = false;
        Cursor.visible = false;
        fpsController.enabled = true;
        cannon.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        inventoryOverOverlay.SetActive(false);
        Time.timeScale = 1;
    }

}
