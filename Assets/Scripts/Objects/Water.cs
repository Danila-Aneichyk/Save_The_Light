using System;
using Names;
using Player;
using UnityEngine;

namespace Objects
{
    public class Water : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                other.gameObject.GetComponentInParent<PlayerHp>().ApplyDamage(_damage);
            }
        }
    }
}