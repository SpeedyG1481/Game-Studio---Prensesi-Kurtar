using UnityEngine;

namespace Sound
{
    public class MusicController : MonoBehaviour
    {
        void Awake()
        {
            DontDestroyOnLoad(transform.gameObject);
        }
    }
}
