using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public string bgMusicName;

    // Start is called before the first frame update
    void Start()
    {
        WizardOzTools.SoundBook book = FindObjectOfType<WizardOzTools.SoundBook>();
        book.PlayMusicNow(bgMusicName);
    }
}
