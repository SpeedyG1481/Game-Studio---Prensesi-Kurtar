using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class PauseButton : MonoBehaviour, IButtonListener
    {
        private Button _button;
        private GameObject _pauseGUI;

        void Start()
        {
            _pauseGUI = GameObject.Find("Tuval").transform.Find("Canvas").gameObject.transform.Find("Pause Screen").gameObject;
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            //if (_pauseGUI == null) return;
            _pauseGUI.SetActive(true);
            Time.timeScale = 0;
            GameController.GameStatus = false;
        }
    }
}