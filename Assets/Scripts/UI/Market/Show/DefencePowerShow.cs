using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Show
{
    public class DefencePowerShow : MonoBehaviour
    {
        private Slider _slider;
        public TextMeshProUGUI text;

        void Start()
        {
            _slider = GetComponent<Slider>();
            _slider.maxValue = GameController.MaxDefencePowerBuff;
        }
    
        void Update()
        {
            _slider.value = GameController.GetUserDefencePowerBuff();
            text.text = GameController.GetDefencePowerCost() <= GameController.DefencePowerCost
                ? "" + GameController.GetDefencePowerCost()
                : "MAX";
        }
    }
}