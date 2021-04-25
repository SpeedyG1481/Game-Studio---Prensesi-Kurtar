using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Show
{
    public class AttackSpeedShow : MonoBehaviour
    {
        private Slider _slider;
        public TextMeshProUGUI text;

        void Start()
        {
            _slider = GetComponent<Slider>();
            _slider.maxValue = GameController.MaxAttackSpeedBuff;
        }

        void Update()
        {
            _slider.value = GameController.GetUserAttackSpeedBuff();
            text.text = GameController.GetAttackSpeedCost() <= GameController.AttackSpeedCost
                ? "" + GameController.GetAttackSpeedCost()
                : "MAX";
        }
    }
}