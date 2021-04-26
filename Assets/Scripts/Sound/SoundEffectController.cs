using UnityEngine;

namespace Sound
{
    public class SoundEffectController : MonoBehaviour
    {
        private static AudioClip _roboShoot,
            _roboAttack,
            _playerAttack,
            _coin,
            _zombieDead,
            _zombieAttack,
            _duckBossAttack,
            _roboBossAttack;

        private static AudioSource _audioSource;


        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _roboShoot = Resources.Load<AudioClip>("Sound/robot_shoot_attack");
            _roboAttack = Resources.Load<AudioClip>("Sound/robo_attack");
            _playerAttack = Resources.Load<AudioClip>("Sound/player_attack");
            _coin = Resources.Load<AudioClip>("Sound/coin_pickup");
            _zombieDead = Resources.Load<AudioClip>("Sound/zombie_dead");
            _zombieAttack = Resources.Load<AudioClip>("Sound/zombie_attack");
            _duckBossAttack = Resources.Load<AudioClip>("Sound/duck_boss_attack");
            _roboBossAttack = Resources.Load<AudioClip>("Sound/robo_boss_attack");
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
                case SoundEnum.ZombieDead:
                    clip = _zombieDead;
                    break;
                case SoundEnum.ZombieAttack:
                    clip = _zombieAttack;
                    break;
                case SoundEnum.DuckBossAttack:
                    clip = _duckBossAttack;
                    break;
                case SoundEnum.RoboBossAttack:
                    clip = _roboBossAttack;
                    break;
            }

            var sound = PlayerPrefs.GetInt("Sound") == 1;
            if (sound && clip != null)
            {
                _audioSource.volume = 1.0F;
                _audioSource.PlayOneShot(clip);
            }
        }
    }
}