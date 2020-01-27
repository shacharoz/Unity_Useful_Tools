using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public string bgMusicName;

    // Start is called before the first frame update
    void Start()
    {
        SoundBook book = FindObjectOfType<SoundBook>();
        book.PlayMusicNow(bgMusicName);
    }
    
}
