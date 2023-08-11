using System.Collections;
using System.Xml.Schema;
using UnityEngine;

namespace Assets.scripts.Shooting
{
    public class Player : MonoBehaviour
    {
        public Bullet bulletPrefab;
        public Transform muzzlePosition;

        public Enemy[] targetEnemies;

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }

        void Fire()
        {
            //随机选一个敌人
            var targetEnemy = targetEnemies[Random.Range(0, targetEnemies.Length)];
            FireOnBullet(targetEnemy, 1, 10);
            FireOnBullet(targetEnemy, 2, 0);
            FireOnBullet(targetEnemy, 3, 0);
            FireOnBullet(targetEnemy, 4, 0);
        }

        void FireOnBullet(Enemy enemy, int offsetIndex, int damage)
        {
            Bullet newBullet = Instantiate(bulletPrefab, muzzlePosition.position, muzzlePosition.rotation);
            newBullet.damage = damage;
            newBullet.baseOffsetIndex = offsetIndex;
            newBullet.SetTarget(enemy.transform);
        }
    }
}