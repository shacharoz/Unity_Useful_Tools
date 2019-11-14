using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;

public class GameStartController : MonoBehaviour
{
    private bool isGameStarted;
    public UnityEngine.Events.UnityEvent OnGameStart;
    public UnityEngine.Events.UnityEvent OnGameEnded;

    //public UnityEngine.Events.UnityEvent OnGameReset;

    public bool UseRightButton;
    public bool UseTwoButtons;
    
    // Start is called before the first frame update
    void Start()
    {
        isGameStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (UseTwoButtons && isGameStarted == false 
        //&& OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch) 
        //&& OVRInput.Get(OVRInput.Button.One,OVRInput.Controller.LTouch)
        ){
            Debug.Log("2 buttons clicked. game should starts");
            GameStarted();
        }
    }

    private void GameStarted(){
        OnGameStart.Invoke();
        isGameStarted = true;
    }

    public void GameEnd(){
        OnGameEnded.Invoke();
        
        //TODO activate this after a few seconds
        ResetGameNow();
    }

    public void ResetGameNow(){
        //OnGameReset.Invoke();

        //reload current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
