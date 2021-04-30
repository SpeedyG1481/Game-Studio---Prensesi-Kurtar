using System;
using UnityEngine;

namespace Parent
{
    public class Entity : MonoBehaviour
    {
        protected static readonly int CharacterAttack = Animator.StringToHash("CharacterAttack");
        private static readonly int CharacterSpeed = Animator.StringToHash("CharacterSpeed");
        protected static readonly int CharacterJump = Animator.StringToHash("CharacterJump");
        private static readonly int CharacterHeal = Animator.StringToHash("CharacterHeal");
        private static readonly int CharacterDead = Animator.StringToHash("CharacterDead");


        public float speedMultiplier = 0.45F;
        public float maxSpeed = 25.0F;
        public float jumpFloat = 475F;
        public float fallDeadPosition = -210F;
        protected float Speed;

        public float health;
        public float maxHealth = 100;

        public float damagePower = 15.5F;
        public float attackSpeed = 1.0F;
        public float defencePower = 10.5F;

        protected Animator Animator;
        public Rigidbody2D rgb;
        protected PolygonCollider2D PolygonCollider2D;

        protected float Timer;
        public float lastAttackTime;


        private void FixedUpdate()
        {
            Animator.SetInteger(CharacterHeal, (int) health);
            Animator.SetFloat(CharacterSpeed, Mathf.Abs(Speed));
            Timer += Time.fixedDeltaTime;
            if (transform.position.y < fallDeadPosition)
            {
                Hit(float.MaxValue);
            }
        }

        private void Start()
        {
            health = maxHealth;
            Animator = GetComponent<Animator>();
            rgb = GetComponent<Rigidbody2D>();
            PolygonCollider2D = GetComponent<PolygonCollider2D>();
        }

        public void Hit(float amount)
        {
            if (IsDead()) return;
            var damage = (float) (amount - (Math.Sqrt(defencePower)));
            health -= damage;
            if (health <= 0)
            {
                health = 0;
                Animator.SetTrigger(CharacterDead);
            }
        }

        protected void Damage(Entity otherEntity)
        {
            if (IsDead() || otherEntity.IsDead()) return;
            otherEntity.Hit(damagePower);
        }

        public bool IsDead()
        {
            return health <= 0;
        }

        protected void IncreaseSpeed(float speed)
        {
            if (IsDead()) return;
            Speed = Speed + speed > maxSpeed ? maxSpeed : Speed + speed;
        }

        protected void DecreaseSpeed(float speed)
        {
            if (IsDead()) return;
            Speed = Speed - speed < 0 ? 0 : Speed - speed;
        }

        protected void SetSpeed(float speed)
        {
            if (IsDead()) return;
            Speed = speed;
            if (Speed > maxSpeed)
            {
                Speed = maxSpeed;
            }
            else if (Speed < 0)
            {
                Speed = 0;
            }
        }

        protected void Kill()
        {
            Destroy(gameObject);
        }
    }
}