using System;
using System.Linq;
using Parent;
using UnityEngine;

public class RoboEnemy : Entity, IAttackable, IShootable, IMoveable, IJumpable
{
    private static readonly int CharacterShoot = Animator.StringToHash("CharacterShoot");
    public float distanceOfDetector = 20F;
    public float shootPower = 10.0F;
    public GameObject bullet;
    private bool _deadStatus = false;

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
            RobotController();
    }


    private bool ContainsPlayer(Collider2D[] collides)
    {
        return collides.Any(subCollider => subCollider.gameObject.CompareTag("Player"));
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    private void RobotController()
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

                var player = subCollider.gameObject.GetComponent<Entity>();
                var distance = Mathf.Abs(player.transform.position.x - transform.position.x);
                if (!player.IsDead())
                {
                    var isOk = Mathf.Abs(Timer % attackSpeed) < 0.35F;
                    if (isOk)
                    {
                        ShootOrAttack(distance);
                    }
                    else
                    {
                        var x = transform.position.x < player.transform.position.x ? 1 : -1;
                        if (distance > 2.8F)
                        {
                            Move(x);
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

    private void ShootOrAttack(float distance)
    {
        if ((!(Timer - lastAttackTime > attackSpeed))) return;
        lastAttackTime = Timer;

        if (distance > 2.8F)
        {
            Shoot();
        }
        else
        {
            Attack();
        }
    }

    public void Attack()
    {
        Animator.SetTrigger(CharacterAttack);

        var collides = Physics2D.OverlapCircleAll(this.transform.position, 2.8F, 1);
        foreach (var collide in collides)
        {
            var otherGameObject = collide.gameObject;
            if (!otherGameObject.CompareTag("Player")) continue;
            var e = otherGameObject.GetComponent<Entity>();
            Damage(e);
        }
    }

    public void Shoot()
    {
        var t = transform;
        Instantiate(bullet, t.position, t.rotation);
        Animator.SetBool(CharacterShoot, true);
    }

    public void ShootDamage(Entity entity)
    {
        entity.Hit(shootPower);
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