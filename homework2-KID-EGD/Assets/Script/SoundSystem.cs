using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace tristan
{
    ///<summary>
    ///soundsystem
    ///</summary>
    ///Required components: The specified components will be added when the script us applied for the first time
    [RequireComponent(typeof(AudioSource))]
    public class SoundSystem : MonoBehaviour
    {
        private AudioSource aud;

        private void Awake()
        {
            aud = GetComponent<AudioSource>();
        }

        /// <summary>
        ///  play sound
        /// </summary>
        /// <param name="sound">want to play sound</param>
        public void PlaySound(AudioClip sound)
        {
            // sound effect source, play the sound effect once(sound);
            aud.PlayOneShot(sound);
        }

    }
}
