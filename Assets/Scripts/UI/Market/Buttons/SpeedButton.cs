using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Buttons
{
    public class SpeedButton : MonoBehaviour, IButtonListener
    {
        private Button _button;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            if (GameController.GetSpeedPowerCost() <= GameController.SpeedCost)
                if (GameController.GetCoin() >= GameController.GetSpeedPowerCost())
                {
                    GameController.RemoveCoin(GameController.GetSpeedPowerCost());
                    GameController.AddUserSpeedPowerBuff();
                }
        }
    }
}