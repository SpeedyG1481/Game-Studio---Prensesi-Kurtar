using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Loader
{
    public class Loading : MonoBehaviour
    {
        public Slider slider;
        public TextMeshProUGUI textMeshPro;
        private bool _isFirstUpdate = true;

        void Update()
        {
            if (_isFirstUpdate)
            {
                SceneLoader.LoaderCallback();
                _isFirstUpdate = false;
            }

            slider.value = SceneLoader.GetProgress * 100.0F;
            textMeshPro.text = "%" + (int) Math.Round(SceneLoader.GetProgress * 100.0F);
        }
    }
}