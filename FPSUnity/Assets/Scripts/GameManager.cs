using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public FPSController fpsController;
    public Cannon cannon;

    public GameObject gameOverOverlay;

    private void Awake()
    {
        Instance = this;
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



}
