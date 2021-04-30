using System;
using Parent;
using Sound;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Entity
{
    public class Character : Parent.Entity, IAttackable, IMoveable, IJumpable
    {
        private HealthBar _healthBar;

        private TextMeshProUGUI _text;
        public float push = 15.0F;
        private float _maxPoint = 0;

        private int _levelPoint = 0;

        public DamageShow damageShow;

        private GameObject _deadGUI;
        private bool _firstUpdate;
        private Joystick _joystick;

        void Update()
        {
            if (!_firstUpdate)
            {
                _firstUpdate = true;
                FirstUpdate();
                MaxPointCalculate();
            }

            if (IsDead())
            {
                if (transform.position.y <= fallDeadPosition)
                {
                    rgb.velocity = Vector2.zero;
                    rgb.gravityScale = 0.0F;
                }
                _deadGUI.SetActive(true);
            }

            if (IsDead() || !GameController.GameStatus) return;
            CharacterController();
            Animator.SetBool(CharacterJump, !Mathf.Approximately(rgb.velocity.y, 0));
            PointBar();
            _healthBar.SetHealth(health);
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void MaxPointCalculate()
        {
            float maxPoint = 0;
            var entities = FindObjectsOfType<Parent.Entity>();
            foreach (var entity in entities)
            {
                if (entity is RoboEnemy)
                {
                    maxPoint += GameController.RoboEnemyPoint * 1.5F;
                }
                else if (entity is ZombieEnemy)
                {
                    maxPoint += GameController.ZombieEnemyPoint * 1.5F;
                }
                else if (entity is GirlZombieEnemy)
                {
                    maxPoint += GameController.GirlZombieEnemyPoint * 1.5F;
                }
                else if (entity is DuckBoss)
                {
                    maxPoint += GameController.DuckBossPoint * 1.25F;
                }
                else if (entity is RoboBoss)
                {
                    maxPoint += GameController.RoboBossPoint * 1.25F;
                }
            }

            _maxPoint = maxPoint;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void PointBar()
        {
            var pointImage1 = GameObject.Find("Star1").GetComponent<Image>();
            var pointImage2 = GameObject.Find("Star2").GetComponent<Image>();
            var pointImage3 = GameObject.Find("Star3").GetComponent<Image>();
            var pointImages = new[] {pointImage1, pointImage2, pointImage3};

            var percentage = _levelPoint / (_maxPoint > 0 ? _maxPoint : 1);

            if (percentage < 0.25F)
            {
                var temp = pointImages[0].color;
                temp.a = 0F;
                pointImages[0].color = temp;

                var temp1 = pointImages[1].color;
                temp1.a = 0F;
                pointImages[1].color = temp1;

                var temp2 = pointImages[2].color;
                temp2.a = 0F;
                pointImages[2].color = temp2;
            }
            else if (percentage >= 0.25F && percentage < 0.65F)
            {
                var temp = pointImages[0].color;
                temp.a = 1F;
                pointImages[0].color = temp;

                var temp1 = pointImages[1].color;
                temp1.a = 0F;
                pointImages[1].color = temp1;

                var temp2 = pointImages[2].color;
                temp2.a = 0F;
                pointImages[2].color = temp2;
            }
            else if (percentage >= 0.65F && percentage < 0.90F)
            {
                var temp = pointImages[0].color;
                temp.a = 1F;
                pointImages[0].color = temp;

                var temp1 = pointImages[1].color;
                temp1.a = 1F;
                pointImages[1].color = temp1;

                var temp2 = pointImages[2].color;
                temp2.a = 0F;
                pointImages[2].color = temp2;
            }
            else if (percentage >= 0.90F)
            {
                var temp = pointImages[0].color;
                temp.a = 1F;
                pointImages[0].color = temp;

                var temp1 = pointImages[1].color;
                temp1.a = 1F;
                pointImages[1].color = temp1;

                var temp2 = pointImages[2].color;
                temp2.a = 1F;
                pointImages[2].color = temp2;
            }

            _text.text = _levelPoint.ToString();
        }


        private int SwitchPointer(Parent.Entity entity)
        {
            if (entity is RoboEnemy)
            {
                return GameController.RoboEnemyPoint;
            }
            else if (entity is ZombieEnemy)
            {
                return GameController.ZombieEnemyPoint;
            }
            else if (entity is GirlZombieEnemy)
            {
                return GameController.GirlZombieEnemyPoint;
            }
            else if (entity is DuckBoss)
            {
                return GameController.DuckBossPoint;
            }
            else if (entity is RoboBoss)
            {
                return GameController.RoboBossPoint;
            }

            return 0;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void FirstUpdate()
        {
            _healthBar = GameObject.Find("HealthBarBG").GetComponent<HealthBar>();
            _text = GameObject.Find("PointText").GetComponent<TextMeshProUGUI>();
            _deadGUI = GameObject.Find("Tuval").transform.Find("Canvas").gameObject.transform.Find("DeadScreen")
                .gameObject;
            _joystick = GameObject.Find("Fixed Joystick").GetComponent<Joystick>();
            GameController.GlobalLevelPointer = 0;
            GameController.GameStatus = true;
            var attackSpeedAttach = GameController.GetUserAttackSpeedBuff();
            var attackDamageAttach = GameController.GetUserAttackDamageBuff();
            var defencePowerAttach = GameController.GetUserDefencePowerBuff();
            var speedAttach = GameController.GetUserSpeedPowerBuff();
            var enemyReducerBuff = GameController.GetEnemyReducerBuff();


            damagePower += attackDamageAttach * 1.1125F;
            attackSpeed -= attackSpeedAttach;
            defencePower += defencePowerAttach * 1.1125F;
            maxSpeed += speedAttach;
            maxHealth += enemyReducerBuff * 22.5F;
            health = maxHealth;
            _healthBar.SetMaxHealth(maxHealth);
            _healthBar.SetHealth(maxHealth);
        }

        private void CharacterController()
        {
            var inputHorizontal = _joystick.Horizontal;
            if (inputHorizontal != 0)
            {
                Move(inputHorizontal);
            }
            else
            {
                SetSpeed(0);
            }
        }

        public void Attack()
        {
            if ((!(Timer - lastAttackTime > attackSpeed))) return;

            Animator.SetTrigger(CharacterAttack);
            lastAttackTime = Timer;
            SoundEffectController.Play(SoundEnum.PlayerAttack);

            var collides = Physics2D.OverlapCircleAll(transform.position, 2.8F, 1);
            foreach (var collide in collides)
            {
                var otherGameObject = collide.gameObject;
                if (!otherGameObject.CompareTag("Enemy")) continue;
                var e = otherGameObject.GetComponent<Parent.Entity>();
                var damage = (float) (damagePower - Math.Sqrt(e.defencePower));

                Damage(e);
                // Push and hit effect
                if (!e.IsDead())
                {
                    _levelPoint += SwitchPointer(e);
                    GameController.GlobalLevelPointer = _levelPoint;
                    var dShow = Instantiate(damageShow, transform.position, Quaternion.Euler(0, 0, 0), transform);
                    dShow.Setup(damage);
                    e.rgb.velocity +=
                        (Math.Round(e.transform.rotation.eulerAngles.y) == 180 ? Vector2.right : Vector2.left) * push;
                }
            }
        }

        public void Move(float x)
        {
            Move(new Vector3(x, 0));
        }

        public void Move(Vector3 vector)
        {
            IncreaseSpeed(speedMultiplier);
            var velocity = new Vector3(vector.x, 0F);
            velocity *= Speed * Time.deltaTime;
            transform.position += velocity;
            var raw = velocity.x > 0 ? 1 : velocity.x < 0 ? -1 : 0;
            if (raw != -1)
            {
                if (raw == 1)
                {
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180f, 0);
            }
        }

        public void Jump()
        {
            if (!Mathf.Approximately(rgb.velocity.y, 0)) return;
            rgb.AddForce(Vector3.up * jumpFloat, ForceMode2D.Impulse);
        }
    }
}