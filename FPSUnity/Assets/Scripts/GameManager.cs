using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public FPSController fpsController;
    public Cannon cannon;

    public GameObject gameOverOverlay;
    public GameObject inventoryOverlay;

    bool isPaused = false;


    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Escape))
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void GameOver()
    {
        //STEP 1 Diable all controls
        fpsController.enabled = false;
        cannon.enabled = false;

        //Step 2 Show Game Over Overlay w Button
        gameOverOverlay.SetActive(true);

        //BONUS Drop Camera

        //Unlock Cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void restartLevel()
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
