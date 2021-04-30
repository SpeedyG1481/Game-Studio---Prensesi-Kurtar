using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class ResumeButton : MonoBehaviour
    {
        private Button _button;
        public GameObject pauseGUI;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            if (pauseGUI == null) return;
            Time.timeScale = 1;
            pauseGUI.SetActive(false);
            GameController.GameStatus = true;
           
        }
    }
}