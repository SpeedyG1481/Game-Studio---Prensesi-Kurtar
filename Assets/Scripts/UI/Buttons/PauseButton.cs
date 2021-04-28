using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class PauseButton : MonoBehaviour, IButtonListener
    {
        private Button _button;
        public GameObject pauseGUI;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            if (pauseGUI == null) return;
            pauseGUI.SetActive(true);
            GameController.GameStatus = false;


        }
    }
}