using UnityEngine;

namespace Sound
{
    public class MusicController : MonoBehaviour
    {
        private AudioSource _source;


        private void Start()
        {
            _source = GetComponent<AudioSource>();
        }

        void Update()
        {
            var sound = PlayerPrefs.GetInt("Sound") == 1;
            if (!sound)
            {
                _source.volume = 0.0F;
            }
            else
            {
                _source.volume = 0.06F;
            }
        }
    }
}