using System;
using UnityEngine;

namespace Parent
{
    public class Entity : MonoBehaviour
    {
        protected static readonly int CharacterAttack = Animator.StringToHash("CharacterAttack");
        protected static readonly int CharacterSpeed = Animator.StringToHash("CharacterSpeed");
        protected static readonly int CharacterJump = Animator.StringToHash("CharacterJump");
        protected static readonly int CharacterHeal = Animator.StringToHash("CharacterHeal");
        protected static readonly int CharacterDead = Animator.StringToHash("CharacterDead");


        public float speedMultiplier = 0.45F;
        public float maxSpeed = 25.0F;
        public float jumpFloat = 475F;
        public float fallDeadPosition = -135F;
        protected float Speed;

        public float health;
        public float maxHealth = 100;

        public float damagePower = 15.5F;
        public float attackSpeed = 1.0F;
        public float defencePower = 10.5F;

        protected Animator Animator;
        protected Rigidbody2D RGB;
        protected PolygonCollider2D PolygonCollider2D;

        protected float Timer = 0F;
        public float lastAttackTime;

        public HealthBar healthBar;


        private void FixedUpdate()
        {
            Animator.SetBool(CharacterJump, !Mathf.Approximately(RGB.velocity.y, 0));
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
            if (healthBar != null)
                healthBar.SetMaxHealth(maxHealth);
            Animator = GetComponent<Animator>();
            RGB = GetComponent<Rigidbody2D>();
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

            if (healthBar != null)
                healthBar.SetHealth(health);
        }

        public void Damage(Entity otherEntity)
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