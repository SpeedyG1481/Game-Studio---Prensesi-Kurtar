using TMPro;
using UnityEngine;

namespace UI.Level
{
    public class BuffBarController : MonoBehaviour
    {
        public TextMeshProUGUI attackDamage;
        public TextMeshProUGUI attackSpeed;
        public TextMeshProUGUI speed;
        public TextMeshProUGUI enemyReduce;
        public TextMeshProUGUI defencePower;

        void Update()
        {
            attackDamage.text = GameController.GetUserAttackDamageBuff() > 0
                ? $"{GameController.GetUserAttackDamageBuff():.##}"
                : "0";
            attackSpeed.text =
                GameController.GetUserAttackSpeedBuff() != 0
                    ? $"{1 / GameController.GetUserAttackSpeedBuff():.##}"
                    : "0";
            speed.text = GameController.GetUserSpeedPowerBuff() > 0
                ? $"{GameController.GetUserSpeedPowerBuff():.##}"
                : "0";
            enemyReduce.text = GameController.GetEnemyReducerBuff() > 0
                ? $"{GameController.GetEnemyReducerBuff():.##}"
                : "0";
            defencePower.text = GameController.GetUserDefencePowerBuff() > 0
                ? $"{GameController.GetUserDefencePowerBuff():.##}"
                : "0";
        }
    }
}