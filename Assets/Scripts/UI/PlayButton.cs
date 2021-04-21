using UI.Loader;
using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class PlayButton : MonoBehaviour, IButtonListener
    {
        private Button _button;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            SceneLoader.Load(Scenes.Level1);
        }
    }
}