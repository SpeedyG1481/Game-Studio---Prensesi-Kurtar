using UI.Parent;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Buttons
{
    public class EnemyReduceButton : MonoBehaviour, IButtonListener
    {
        private Button _button;

        void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        public void OnClick()
        {
            if (GameController.GetEnemyReducerCost() <= GameController.EnemyReducerCost)
                if (GameController.GetCoin() >= GameController.GetEnemyReducerCost())
                {
                    GameController.RemoveCoin(GameController.GetEnemyReducerCost());
                    GameController.AddEnemyReducerBuff();
                }
        }
    }
}