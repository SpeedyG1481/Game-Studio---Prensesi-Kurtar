using UnityEngine;

namespace Other
{
    public class DamageEffect : MonoBehaviour
    {
        void Start()
        {
            Destroy(gameObject, 2.5F);
        }
    }
}