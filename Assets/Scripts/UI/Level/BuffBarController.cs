using System;
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
            attackDamage.text = String.Format("{0:.##}", GameController.GetUserAttackDamageBuff());
            attackSpeed.text = String.Format("{0:.##}", 1 / GameController.GetUserAttackSpeedBuff());
            speed.text = String.Format("{0:.##}", GameController.GetUserSpeedPowerBuff());
            enemyReduce.text = String.Format("{0:.##}", GameController.GetEnemyReducerBuff());
            defencePower.text = String.Format("{0:.##}", GameController.GetUserDefencePowerBuff());
        }
    }
}