using TMPro;
using UnityEngine;

namespace UI.Market.Show.Coin
{
    public class CoinShow : MonoBehaviour
    {
        private TextMeshProUGUI _textMeshPro;

        void Start()
        {
            _textMeshPro = GetComponent<TextMeshProUGUI>();
        }

        void Update()
        {
            _textMeshPro.text = "" + GameController.GetCoin();
        }
    }
}