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

    public int ammo = 20;
    public TextMeshProUGUI ammoText;

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
}
