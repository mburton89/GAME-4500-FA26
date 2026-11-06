using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public FPSController fpsController;
    public Cannon cannon;

    public GameObject gameOverOverlay;
    public GameObject inventoryOverlay;

    bool isPaused = false;

    public Button buttonToAutoSelect;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
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
        //step 1 no control step 2 blood effects step 3 game over text step 4 camera drop
        fpsController.enabled = false;
        cannon.enabled = false;

        gameOverOverlay.SetActive(true);

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
        isPaused = true;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        inventoryOverlay.SetActive(true);

        fpsController.enabled = false;
        cannon.enabled = false;

        buttonToAutoSelect.Select();

        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        inventoryOverlay.SetActive(false);

        fpsController.enabled = true;
        cannon.enabled = true;

        Time.timeScale = 1;
    }
}
