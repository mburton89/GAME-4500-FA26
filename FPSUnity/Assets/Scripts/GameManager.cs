using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public FPSController fpsController;
    public Cannon cannon;

    public GameObject gameOverOverlay;

    public GameObject InventoryOverlay;
    bool isPaused = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused)
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

    void PauseGame()
    {
        isPaused = true;

        //enables cursor during pause
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        InventoryOverlay.SetActive(true);
        
        //disables cannon
        fpsController.enabled = false;
        cannon.enabled = false;

        //pauses everything in game
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        isPaused = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        InventoryOverlay.SetActive(false);

        fpsController.enabled = true;
        cannon.enabled = true;

        Time.timeScale = 1;
    }

}
