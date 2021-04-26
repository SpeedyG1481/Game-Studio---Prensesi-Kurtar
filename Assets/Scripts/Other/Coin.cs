using Sound;
using UnityEngine;

namespace Other
{
    public class Coin : MonoBehaviour
    {
        public int coinValue = 1;
        public float flipSpeed = 0.1F;
        public ParticleSystem effect;
        public GameObject completeLevelGUI;
        public Parent.Entity[] mustBeDead;

        void Update()
        {
            transform.Rotate(0, flipSpeed, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject);
                GameController.AddCoin(coinValue);
                SoundEffectController.Play(SoundEnum.Coin);
            }
        }
    }
}