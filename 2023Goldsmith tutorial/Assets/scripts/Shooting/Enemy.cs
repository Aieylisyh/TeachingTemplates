using System.Collections;
using UnityEngine;

namespace Assets.scripts.Shooting
{
    public class Enemy : MonoBehaviour
    {
        public int hpMax;
        public int hp;
        public HpBarBehaviour hpBar;

        // Use this for initialization
        void Start()
        {
            hp = hpMax;
            hpBar.Set(1, true);
            hpBar.Show();
        }

        public void FullFillHp()
        {
            hp = hpMax;
            hpBar.Set(1, true);
            hpBar.Show();
        }

        public void OnDamaged(int damage)
        {
            if (damage <= 0)
            {
                return;
            }


            hp -= damage;
            SyncHpBar();
        }

        void SyncHpBar()
        {
            hpBar.Set((float)hp / hpMax, false);
        }
    }
}