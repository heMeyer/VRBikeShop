using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Load scene using name, or reload the active scene
/// </summary>
public class LoadScene : MonoBehaviour
{
    public void LoadSceneUsingName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadCurrentScene()
    {
        /*
        int sC = 2;
        //Scene[] scenes = new Scene[sC];

        Debug.Log("Scene loader on");

        for(int i = 0; i < sC; i++)
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(i).name);
            Debug.Log("Scene " + i + " loaded");
        }
        */

        SceneManager.LoadScene("FloorPlan");
    }
}
