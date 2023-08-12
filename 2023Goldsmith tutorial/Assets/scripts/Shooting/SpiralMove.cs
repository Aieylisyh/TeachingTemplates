using System.Collections;
using UnityEngine;

namespace Assets.scripts.Shooting
{
    public class SpiralMove : MonoBehaviour
    {
        public float randianSpeed;
        public float upSpeed;
        public float radiusSpeed;
        public float radius;
        float _radian;
        Vector3 _startPos;
        public float offset;

        private void Start()
        {
            _startPos = transform.position;
            _radian = 0;
        }

        void Update()
        {
            var dt = Time.deltaTime;
            radius += dt * radiusSpeed;
            _radian += dt * randianSpeed;

            _startPos += upSpeed * Vector3.up * dt;

            transform.position = _startPos
                + radius * Mathf.Sin(_radian + offset) * Vector3.forward
                + radius * Mathf.Cos(_radian + offset) * Vector3.right;
        }
    }
}