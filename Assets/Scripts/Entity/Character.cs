using Parent;
using Sound;
using UnityEngine;

public class Character : Entity, IAttackable, IMoveable, IJumpable
{
    private IAttackable _attackableImplementation;

    void Update()
    {
        if (IsDead()) return;
        CharacterController();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void CharacterController()
    {
        var inputHorizontal = Input.GetAxis("Horizontal");
        if (inputHorizontal != 0)
        {
            Move(inputHorizontal);
        }
        else
        {
            SetSpeed(0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }


        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if ((!(Timer - lastAttackTime > attackSpeed))) return;

        Animator.SetTrigger(CharacterAttack);
        lastAttackTime = Timer;

        var collides = Physics2D.OverlapCircleAll(this.transform.position, 2.8F, 1);
        foreach (var collide in collides)
        {
            var otherGameObject = collide.gameObject;
            if (!otherGameObject.CompareTag("Enemy")) continue;
            var e = otherGameObject.GetComponent<Entity>();
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
        SoundEffectController.Play(SoundEnum.PlayerMove);
    }

    public void Jump()
    {
        if (!Mathf.Approximately(RGB.velocity.y, 0)) return;
        RGB.AddForce(Vector3.up * jumpFloat, ForceMode2D.Impulse);
    }
}