using UnityEngine;

namespace Sound
{
    public class SoundEffectController : MonoBehaviour
    {
        private static AudioClip _roboShoot, _roboAttack, _playerAttack, _coin;
        private static AudioSource _audioSource;


        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _roboShoot = Resources.Load<AudioClip>("Sound/robot_shoot_attack");
            _roboAttack = Resources.Load<AudioClip>("Sound/robo_attack");
            _playerAttack = Resources.Load<AudioClip>("Sound/player_attack");
            _coin = Resources.Load<AudioClip>("Sound/coin_pickup");
        }


        public static void Play(SoundEnum @enum)
        {
            AudioClip clip = null;
            switch (@enum)
            {
                case SoundEnum.RoboShoot:
                    clip = _roboShoot;
                    break;
                case SoundEnum.RoboAttack:
                    clip = _roboAttack;
                    break;
                case SoundEnum.PlayerAttack:
                    clip = _playerAttack;
                    break;
                case SoundEnum.Coin:
                    clip = _coin;
                    break;
            }

            if (clip != null)
            {
                _audioSource.volume = 1.0F;
                _audioSource.PlayOneShot(clip);
            }
        }
    }
}