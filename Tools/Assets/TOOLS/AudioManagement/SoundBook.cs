using System.Collections.Generic;
using UnityEngine;

namespace WizardOzTools
{
    public class SoundBook : MonoBehaviour
    {
        public List<AudioFile> fxFiles;
        public AudioSource audioPlayer;

        public List<AudioFile> bgMusics;
        public AudioSource bgMusicPlayer;


        // Start is called before the first frame update
        void Awake()
        {
            if (bgMusicPlayer == null && bgMusics.Count > 0)
            {
                bgMusicPlayer = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
                bgMusicPlayer.playOnAwake = false;
                bgMusicPlayer.loop = true;
            }

            if (audioPlayer == null && fxFiles.Count > 0)
            {
                audioPlayer = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
                audioPlayer.playOnAwake = false;
                audioPlayer.loop = false;
            }
        }

        public AudioClip GetClipByPurpose(string filename)
        {
            foreach (AudioFile audio in fxFiles)
            {
                if (audio.purpose == filename)
                {
                    return audio.clip;
                }
            }

            Debug.LogError("no clip found in sound book with that name: " + filename);
            return null;
        }

        public void PlayFxNow(string filename)
        {
            AudioClip clip = GetClipByPurpose(filename);
            if (clip != null)
            {
                audioPlayer.clip = clip;
                audioPlayer.Play();
            }
        }

        public void PlayMusicNow(string filename)
        {
            foreach (AudioFile music in bgMusics)
            {
                if (music.purpose == filename)
                {
                    bgMusicPlayer.clip = music.clip;
                    bgMusicPlayer.Play();

                    break;
                }
            }
        }

        public void StopMusicNow()
        {
            bgMusicPlayer.Stop();
        }
    }

    [System.Serializable]
    public class AudioFile
    {
        public string purpose;
        public AudioClip clip;
    }
}