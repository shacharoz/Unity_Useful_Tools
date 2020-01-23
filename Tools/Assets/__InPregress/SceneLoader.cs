using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void LoadSceneNow(string _sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_sceneName);
    }
}
