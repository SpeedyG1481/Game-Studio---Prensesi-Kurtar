using UI.Loader;
using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class WhoButton : MonoBehaviour, IButtonListener
    {
        private Button _button;


        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }


        public void OnClick()
        {
            Application.OpenURL("https://studio.megalowofficial.com/");
        }
    }
}