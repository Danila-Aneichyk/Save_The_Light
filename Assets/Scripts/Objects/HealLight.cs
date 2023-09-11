using System;
using Names;
using Player;
using UnityEngine;

namespace Objects
{
    public class HealLight : MonoBehaviour
    {
        private int _heal = 1;

        public static event Action OnScoreChanged;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                other.gameObject.GetComponentInParent<PlayerHp>().ApplyHeal(_heal);
                OnScoreChanged?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}