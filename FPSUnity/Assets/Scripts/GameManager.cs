using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public FPSController fpsController;
    public Cannon cannon;

    public GameObject gameOverOverlay;
    //public Button restartGameButton;

    private void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void GameOver()
    {
        //Disable All Controls
        fpsController.enabled = false;
        cannon.enabled = false;

        //Show Game Over Screen w/ Button
        gameOverOverlay.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //Drop Camera

        
    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

    
}
