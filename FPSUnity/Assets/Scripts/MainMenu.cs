using UnityEngine;
using UnityEngine.SceneManagement; 

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        // Loads the next scene in the queue (Build Index 1)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        // Closes the application
        Debug.Log("Quit Game Pressed!"); // Visible only in the Unity Editor
        Application.Quit();
    }
}