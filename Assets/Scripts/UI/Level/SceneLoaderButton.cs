using UI.Loader;
using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    public class SceneLoaderButton : MonoBehaviour, IButtonListener
    {
        public Scenes scene;
        private Button _button;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            SceneLoader.Load(scene);
        }
    }
}