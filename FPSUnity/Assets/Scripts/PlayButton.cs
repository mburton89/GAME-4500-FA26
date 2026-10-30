using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    
    public void SwitchToGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
