using Sound;
using TMPro;
using UI.Loader;
using UnityEngine;

namespace Other
{
    public class LevelEndCoin : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        private GameObject _completeLevelGUI;

        private float _timer;
        private bool _isEnded;

        private int coinValue = 10;
        public float flipSpeed = 0.1F;
        public ParticleSystem effect;

        public Parent.Entity[] mustBeDead;
        public Scenes level;

        private void Start()
        {
            _text = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
            _completeLevelGUI =GameObject.Find("Tuval").transform.Find("Canvas").gameObject.transform.Find("EndLevelScreen").gameObject;
            _timer = 0;
        }

        void Update()
        {
            if (!_isEnded)
            {
                _timer += Time.deltaTime;
                GameController.GlobalLevelTimer = _timer;
            }

            _text.text = _timer.ToString("F1");
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
                    _completeLevelGUI.SetActive(true);
                    _isEnded = true;
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