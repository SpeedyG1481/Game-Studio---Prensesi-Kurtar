using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Show
{
    public class AttackDamageShow : MonoBehaviour
    {
        private Slider _slider;
        public TextMeshProUGUI text;

        void Start()
        {
            _slider = GetComponent<Slider>();
            _slider.maxValue = GameController.MaxAttackDamageBuff;
        }

        void Update()
        {
            _slider.value = GameController.GetUserAttackDamageBuff();
            text.text = GameController.GetAttackDamageCost() <= GameController.AttackDamageCost
                ? "" + GameController.GetAttackDamageCost()
                : "MAX";
        }
    }
}