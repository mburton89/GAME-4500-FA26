using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    int nextSceneIndex;
    public SceneAsset scene;

    public void Start()
    {
        nextSceneIndex = scene.buildIndex;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }
}
