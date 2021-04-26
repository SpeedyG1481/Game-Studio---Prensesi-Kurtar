using System.Linq;
using Parent;
using UnityEngine;

namespace Entity
{
    public class GirlZombieEnemy : Parent.Entity, IAttackable, IMoveable, IJumpable
    {
        private bool _deadStatus = false;
        public float distanceOfDetector = 20F;
        private bool _firstUpdate;

        private void FirstUpdate()
        {
            var enemyReduce = GameController.GetEnemyReducerBuff();
            damagePower -= enemyReduce / 2.5F;
            defencePower -= enemyReduce / 2.5F;
            maxHealth -= enemyReduce * 2;
            health = maxHealth;
        }

        void Update()
        {
            if (!_firstUpdate)
            {
                _firstUpdate = true;
                FirstUpdate();
            }

            if (!GameController.GameStatus) return;

            if (IsDead() && !_deadStatus)
            {
                _deadStatus = true;
                PolygonCollider2D.isTrigger = true;
                RGB.gravityScale = 0F;
                Invoke("Kill", 5.5F);
            }
            else if (!IsDead())
            {
                ZombieController();
                Animator.SetBool(CharacterJump, !Mathf.Approximately(RGB.velocity.y, 0));
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        private void ZombieController()
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
                        if (distance > 3.45F)
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

        // ReSharper disable Unity.PerformanceAnalysis
        public void Attack()
        {
            if ((!(Timer - lastAttackTime > attackSpeed))) return;
            lastAttackTime = Timer;
            Animator.SetTrigger(CharacterAttack);
            var collides = Physics2D.OverlapCircleAll(transform.position, 3.45F, 1);
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