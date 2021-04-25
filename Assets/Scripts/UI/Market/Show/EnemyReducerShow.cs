using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Show
{
    public class EnemyReducerShow : MonoBehaviour
    {
        private Slider _slider;
        public TextMeshProUGUI text;

        void Start()
        {
            _slider = GetComponent<Slider>();
            _slider.maxValue = GameController.MaxEnemyReducerBuff;
        }

        void Update()
        {
            _slider.value = GameController.GetEnemyReducerBuff();
            text.text = GameController.GetEnemyReducerCost() <= GameController.EnemyReducerCost
                ? "" + GameController.GetEnemyReducerCost()
                : "MAX";
        }
    }
}