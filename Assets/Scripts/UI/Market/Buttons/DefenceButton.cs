using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Buttons
{
    public class DefenceButton : MonoBehaviour, IButtonListener
    {
        private Button _button;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            if (GameController.GetDefencePowerCost() <= GameController.DefencePowerCost)
                if (GameController.GetCoin() >= GameController.GetDefencePowerCost())
                {
                    GameController.RemoveCoin(GameController.GetDefencePowerCost());
                    GameController.AddUserDefencePowerBuff();
                }
        }
    }
}