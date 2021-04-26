using Sound;
using UI.Loader;
using UnityEngine;

namespace Other
{
    public class LevelEndCoin : MonoBehaviour
    {
        private int coinValue = 10;
        public float flipSpeed = 0.1F;
        public ParticleSystem effect;
        public GameObject completeLevelGUI;
        public Parent.Entity[] mustBeDead;
        public Scenes level;

        void Update()
        {
            transform.Rotate(0, flipSpeed, 0);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                if (effect != null && MustBeDeadIterator())
                {
                    Destroy(gameObject);
                    GameController.AddCoin(coinValue);
                    SoundEffectController.Play(SoundEnum.Coin);
                    GameController.GameStatus = false;
                    Instantiate(effect, transform.position, Quaternion.Euler(0, 0, 0));
                    completeLevelGUI.SetActive(true);
                    EndLevel();
                }
            }
        }

        private void EndLevel()
        {
            var currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            if (currentLevel < (int) level)
            {
                PlayerPrefs.SetInt("CurrentLevel", currentLevel + 1);
            }
        }

        private bool MustBeDeadIterator()
        {
            if (mustBeDead != null)
                foreach (var e in mustBeDead)
                {
                    if (!e.IsDead())
                    {
                        return false;
                    }
                }

            return true;
        }
    }
}