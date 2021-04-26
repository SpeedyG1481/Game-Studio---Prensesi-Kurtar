using UI.Loader;
using UI.Parent;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

namespace UI.Buttons
{
    public class PlayButton : MonoBehaviour, IButtonListener
    {
        private Button _button;
        private float _speed = 1.25f;
        private RectTransform _rectTransform;
        private float _amount;
        private bool _sinCos = false;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
            var r = new Random();
            _amount = (float) r.NextDouble();
            if (r.Next(100) >= 50)
            {
                _amount = -_amount;
            }

            if (r.Next(100) >= 50)
            {
                _sinCos = true;
            }

            _rectTransform = GetComponent<RectTransform>();
        }


        private void Shake()
        {
            _rectTransform.Rotate(new Vector3(0F, 0,
                (_sinCos ? Mathf.Sin(Time.time * _speed) : Mathf.Cos(Time.time * _speed)) * _amount));
        }

        public void OnClick()
        {
            SceneLoader.Load(Scenes.Levels);
        }

        void Update()
        {
            Shake();
        }
    }
}