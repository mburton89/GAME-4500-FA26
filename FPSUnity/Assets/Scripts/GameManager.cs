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

}
