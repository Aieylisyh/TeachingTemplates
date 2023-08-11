using System.Collections;
using UnityEngine;

namespace Assets.scripts.Shooting
{
    public class Bullet : MonoBehaviour
    {
        public int damage;
        public float speed = 15;
        public AnimationCurve ac;

        float _timeToHit;
        float _timeFromStart;
        Vector3 _dir;
        Vector3 _virtualPos;
        public float amplitude;
        public Vector3 baseOffset = Vector3.up;
        public int baseOffsetIndex = 1;

        private void OnTriggerEnter(Collider other)
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.OnDamaged(damage);
                Destroy(this.gameObject);
            }
        }

        public void SetTarget(Transform t)
        {
            var distance = t.localPosition - transform.position;
            _dir = distance.normalized;
            _timeToHit = distance.magnitude / speed;
            _timeFromStart = 0;

            _virtualPos = transform.position;

            transform.LookAt(t);

            switch (baseOffsetIndex)
            {
                case 1:
                    baseOffset = transform.up;
                    break;
                case 2:
                    baseOffset = -transform.up;
                    break;
                case 3:
                    baseOffset = transform.right;
                    break;
                case 4:
                    baseOffset = -transform.right;
                    break;
            }

            baseOffset = baseOffset * Random.Range(0.7f, 1.3f);
        }

        private void Update()
        {
            _virtualPos += _dir * speed * Time.deltaTime;

            _timeFromStart += Time.deltaTime;
            var ratio = _timeFromStart / _timeToHit;
            var heightOffset = ac.Evaluate(ratio);

            transform.position = _virtualPos + baseOffset * heightOffset * amplitude;
        }
    }
}