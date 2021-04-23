using System.Linq;
using Parent;
using UnityEngine;

namespace Entity
{
    public class RoboBoss : Parent.Entity, IAttackable, IMoveable
    {
        public float distanceOfDetector = 35F;
        private bool _deadStatus;

        void Update()
        {
            if (IsDead() && !_deadStatus)
            {
                _deadStatus = true;
                PolygonCollider2D.isTrigger = true;
                RGB.gravityScale = 0F;
                Invoke("Kill", 5.5F);
            }
            else if (!IsDead())
                BossController();
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void BossController()
        {
            var collides = Physics2D.OverlapCircleAll(this.transform.position, distanceOfDetector);
            if (ContainsPlayer(collides))
            {
                foreach (var subCollider in collides)
                {
                    if (!subCollider.gameObject.CompareTag("Player"))
                    {
                        continue;
                    }

                    var player = subCollider.gameObject.GetComponent<Parent.Entity>();
                    var distance = Mathf.Abs(player.transform.position.x - transform.position.x);
                    if (!player.IsDead())
                    {
                        if (distance > 3.5F)
                        {
                            var x = transform.position.x < player.transform.position.x ? 1 : -1;
                            Move(x);
                        }
                        else
                        {
                            var isOk = Mathf.Abs(Timer % attackSpeed) < 0.35F;
                            if (isOk)
                            {
                                Attack();
                            }
                            else
                            {
                                SetSpeed(0);
                            }
                        }
                    }

                    break;
                }
            }
            else
            {
                SetSpeed(0);
            }
        }


        private bool ContainsPlayer(Collider2D[] collides)
        {
            return collides.Any(subCollider => subCollider.gameObject.CompareTag("Player"));
        }

        public void Attack()
        {
            if ((!(Timer - lastAttackTime > attackSpeed))) return;
            lastAttackTime = Timer;
            Animator.SetTrigger(CharacterAttack);
            var collides = Physics2D.OverlapCircleAll(transform.position, 3.5F, 1);
            foreach (var collide in collides)
            {
                var otherGameObject = collide.gameObject;
                if (!otherGameObject.CompareTag("Player")) continue;
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
                    transform.rotation = Quaternion.Euler(0, 180f, 0);
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0f, 0);
            }
        }
    }
}