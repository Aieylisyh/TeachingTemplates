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
                Fire();
            if (Input.GetMouseButtonDown(1))
                ResetTargetsHp();
        }

        void ResetTargetsHp()
        {
            foreach (Enemy enemy in targetEnemies)
                enemy.FullFillHp();
        }

        void Fire()
        {
            //随机选一个敌人
            var targetEnemy = targetEnemies[Random.Range(0, targetEnemies.Length)];
            FireOnBullet(targetEnemy, 1, 10, Random.Range(13f, 17f));
            FireOnBullet(targetEnemy, 2, 10, Random.Range(13f, 17f));
            FireOnBullet(targetEnemy, 3, 10, Random.Range(13f, 17f));
            FireOnBullet(targetEnemy, 4, 10, Random.Range(13f, 17f));
        }

        void FireOnBullet(Enemy enemy, int offsetIndex, int damage, float speed = 15)
        {
            Bullet newBullet = Instantiate(bulletPrefab, muzzlePosition.position, muzzlePosition.rotation);
            newBullet.damage = damage;
            newBullet.speed = speed;
            newBullet.baseOffsetIndex = offsetIndex;
            newBullet.SetTarget(enemy.transform);
        }
    }
}