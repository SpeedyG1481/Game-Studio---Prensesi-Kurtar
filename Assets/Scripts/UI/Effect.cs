using UnityEngine;

namespace UI
{
    public class Effect : MonoBehaviour
    {
        private float _speed = 1.25f;
        private float _amount = 0.5f;
        RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        void Update()
        {
            Shake();
        }

        private void Shake()
        {
            _rectTransform.Rotate(new Vector3(0F, Mathf.Sin(Time.time * _speed) * _amount));
        }
    }
}