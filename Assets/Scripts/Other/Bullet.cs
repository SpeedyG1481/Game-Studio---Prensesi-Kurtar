using Sound;
using UnityEngine;

namespace Other
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 35F;
        public float maxDistance = 135F;
        public float power = 10.0F;
        private Rigidbody2D _rigidbody2D;
        private float _startPosition;
        public ParticleSystem effect;

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            var transform1 = transform;
            _rigidbody2D.velocity = ((int) transform1.rotation.y == -1 ? Vector2.left : Vector2.right) * speed;
            _startPosition = transform1.position.x;
            SoundEffectController.Play(SoundEnum.RoboShoot);
        }

        private void Update()
        {
            if (DistanceController())
            {
                Kill();
            }
        }

        private bool DistanceController()
        {
            var currentPosition = transform.position.x;
            var delta = Mathf.Abs(_startPosition - currentPosition);
            return (delta >= maxDistance);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other == null) return;

            if (!other.gameObject.CompareTag("Player")) return;
            var character = other.gameObject.GetComponent<Parent.Entity>();
            character.Hit(power);
            ParticleEffect();
            Kill();
        }

        private void ParticleEffect()
        {
            Instantiate(effect, transform.position, transform.rotation);
        }


        private void Kill()
        {
            Destroy(gameObject);
        }
    }
}