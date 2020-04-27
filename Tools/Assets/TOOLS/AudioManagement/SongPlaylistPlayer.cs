using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WizardOzTools
{
    /// <summary>
    /// plays a playlist of songs one after the other, repeatedly
    /// </summary>
    public class SongPlaylistPlayer : MonoBehaviour
    {
        public List<AudioFile> songs;
        public AudioSource audioPlayer;
        private int index;
        private bool isPlaying;
        
        void Start()
        {
            if (audioPlayer == null && songs.Count > 0)
            {
                audioPlayer = gameObject.AddComponent(typeof(AudioSource)) as AudioSource;
                audioPlayer.playOnAwake = false;
                audioPlayer.loop = false;
            }

            index = 0;
            isPlaying = false;
        }

        public void PlayNextSong()
        {
            index = (index + 1 >= songs.Count) ? 0 : index + 1;
            PlaySong();
        }
        public void PlayPreviousSong()
        {
            index = (index - 1 < 0) ? songs.Count-1 : index - 1;
            PlaySong();
        }

        public void PlaySong()
        {
            if (audioPlayer.clip != songs[index].clip)
            {
                audioPlayer.clip = songs[index].clip;
            }
            
            audioPlayer.Play();
            isPlaying = true;
        }

        public void PauseSong()
        {
            audioPlayer.Pause();
            isPlaying = false;
        }

        /// <summary>
        /// volume value between 0 to 1
        /// </summary>
        /// <param name="value"></param>
        public void SetVolume(float value)
        {
            audioPlayer.volume = value;
        }
    }
}