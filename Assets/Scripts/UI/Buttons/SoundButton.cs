using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class SoundButton : MonoBehaviour, IButtonListener
    {
        private Button _button;
        private Image _image;

        void Start()
        {
            _button = GetComponent<Button>();
            _image = GetComponent<Image>();
            _button.onClick.AddListener(OnClick);
        }


        public void OnClick()
        {
            var sound = PlayerPrefs.GetInt("Sound") == 1;
            sound = !sound;
            PlayerPrefs.SetInt("Sound", (sound ? 1 : 0));
        }
    }
}