using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Buttons
{
    public class AttackDamageButton : MonoBehaviour, IButtonListener
    {
        private Button _button;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            
            if (GameController.GetAttackDamageCost() <= GameController.AttackDamageCost)
                if (GameController.GetCoin() >= GameController.GetAttackDamageCost())
                {
                    GameController.RemoveCoin(GameController.GetAttackDamageCost());
                    GameController.AddUserAttackDamageBuff();
                }
        }
    }
}