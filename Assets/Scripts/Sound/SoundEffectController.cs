using Sound;
using UnityEngine;

public class SoundEffectController : MonoBehaviour
{
    private static AudioClip _roboShoot, _roboAttack, _playerAttack, _playerMove;
    private static AudioSource _audioSource;


    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _roboShoot = Resources.Load<AudioClip>("Sound/robot_shoot_attack");
        _roboAttack = Resources.Load<AudioClip>("Sound/robo_attack");
        _playerAttack = Resources.Load<AudioClip>("Sound/player_attack");
        _playerMove = Resources.Load<AudioClip>("Sound/player_run");
    }


    public static void Play(SoundEnum @enum)
    {
        switch (@enum)
        {
            case SoundEnum.RoboShoot:
                _audioSource.PlayOneShot(_roboShoot);
                break;
            case SoundEnum.RoboAttack:
                _audioSource.PlayOneShot(_roboAttack);
                break;
            case SoundEnum.PlayerAttack:
                _audioSource.PlayOneShot(_playerAttack);
                break;
            case SoundEnum.PlayerMove:
                _audioSource.PlayOneShot(_playerMove);
                break;
        }
    }
}