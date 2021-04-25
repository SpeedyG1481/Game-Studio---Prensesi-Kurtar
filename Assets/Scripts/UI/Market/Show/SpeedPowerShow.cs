using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Market.Show
{
    public class SpeedPowerShow : MonoBehaviour
    {
        private Slider _slider;
        public TextMeshProUGUI text;

        void Start()
        {
            _slider = GetComponent<Slider>();
            _slider.maxValue = GameController.MaxSpeedPowerBuff;
        }

        void Update()
        {
            _slider.value = GameController.GetUserSpeedPowerBuff();
            text.text = GameController.GetSpeedPowerCost() <= GameController.SpeedCost
                ? "" + GameController.GetSpeedPowerCost()
                : "MAX";
        }
    }
}