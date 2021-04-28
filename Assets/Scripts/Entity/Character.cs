using Parent;
using Sound;
using UnityEngine;
using UnityEngine.UI;

namespace Entity
{
    public class Character : Parent.Entity, IAttackable, IMoveable, IJumpable
    {
        public GameObject deadGUI;
        private bool _firstUpdate;
        public Joystick joystick;
        public Button attackButton;
        public Button jumpButton;

        void Update()
        {
            if (!_firstUpdate)
            {
                _firstUpdate = true;
                FirstUpdate();
            }

            if (IsDead())
            {
                deadGUI.SetActive(true);
                if (transform.position.y <= fallDeadPosition)
                {
                    RGB.velocity = Vector2.zero;
                    RGB.gravityScale = 0.0F;
                }
            }

            if (IsDead() || !GameController.GameStatus) return;
            CharacterController();
            Animator.SetBool(CharacterJump, !Mathf.Approximately(RGB.velocity.y, 0));
        }

        private void FirstUpdate()
        {
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

            attackButton.onClick.AddListener(AttackButtonListener);
            jumpButton.onClick.AddListener(JumpButtonListener);
        }

        private void JumpButtonListener()
        {
            if (!IsDead())
                Jump();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void AttackButtonListener()
        {
            if (!IsDead())
                Attack();
        }

        private void CharacterController()
        {
            var inputHorizontal = joystick.Horizontal;
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
            var collides = Physics2D.OverlapCircleAll(this.transform.position, 2.8F, 1);
            foreach (var collide in collides)
            {
                var otherGameObject = collide.gameObject;
                if (!otherGameObject.CompareTag("Enemy")) continue;
                var e = otherGameObject.GetComponent<Parent.Entity>();
                Damage(e);
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
            if (!Mathf.Approximately(RGB.velocity.y, 0)) return;
            RGB.AddForce(Vector3.up * jumpFloat, ForceMode2D.Impulse);
        }
    }
}