using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public FPSController fpsController;
    public Canon canon;

    public GameObject gameOverOverlay;
    // Make it easier to talk to class and get access to methods

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        //Step 1: Disable all controls .enabled to turn on something that was enabled from the start

        fpsController.enabled = false;
        canon.enabled = false;

        //Step 2: Show Game Over Overlay - restart button .SetActuve to turn something active that wasn't enabled from the start.
        gameOverOverlay.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        //BONUS: Drop Camera

    }

    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }

   
}
