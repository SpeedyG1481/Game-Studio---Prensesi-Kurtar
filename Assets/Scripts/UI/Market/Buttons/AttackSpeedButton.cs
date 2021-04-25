using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Buttons
{
    public class AttackSpeedButton : MonoBehaviour, IButtonListener
    {
        private Button _button;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            if (GameController.GetAttackSpeedCost() <= GameController.AttackSpeedCost)
                if (GameController.GetCoin() >= GameController.GetAttackSpeedCost())
                {
                    GameController.RemoveCoin(GameController.GetAttackSpeedCost());
                    GameController.AddUserAttackSpeedPowerBuff();
                }
        }
    }
}