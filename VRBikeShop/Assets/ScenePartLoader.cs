using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePartLoader : MonoBehaviour
{
    //scene state
    private bool isLoaded;
    private bool shouldLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TriggerCheck();
    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Collided und so");

        if (other.CompareTag("RightController"))
        {
            shouldLoad = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RightController"))
        {
            shouldLoad = false;
        }
    }

    void TriggerCheck()
    {
        if(shouldLoad)
        {
            LoadScene();
        } else {
            UnloadScene();
        }
    }

    void LoadScene()
    {
        if(!isLoaded)
        {
            SceneManager.LoadSceneAsync(gameObject.name, LoadSceneMode.Additive);
            isLoaded = true;
        }

    }

    void UnloadScene()
    {
        if(isLoaded)
        {
            SceneManager.UnloadSceneAsync(gameObject.name);
            isLoaded = false;
        }
    }
}
