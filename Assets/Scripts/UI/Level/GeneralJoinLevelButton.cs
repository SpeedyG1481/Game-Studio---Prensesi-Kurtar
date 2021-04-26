using TMPro;
using UI.Loader;
using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    public class GeneralJoinLevelButton : MonoBehaviour, IButtonListener
    {
        private Button _button;
        public Scenes scene;
        public TextMeshProUGUI text;
        private int startIndex = 5;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }


        void Update()
        {
            var currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            if (((int) scene - startIndex) > currentLevel)
            {
                text.text = "?";
            }
        }

        public void OnClick()
        {
            if (scene != null)
            {
                var currentLevel = PlayerPrefs.GetInt("CurrentLevel");
                if (((int) scene - startIndex) <= currentLevel)
                {
                    SceneLoader.Load(scene);
                }
            }
        }
    }
}