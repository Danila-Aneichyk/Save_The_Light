using Names;
using Player;
using UnityEngine;

namespace Objects
{
    public class HealLight : MonoBehaviour
    {
        private int _heal = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                other.gameObject.GetComponentInParent<PlayerHp>().ApplyHeal(_heal);
                Destroy(gameObject);
            }
        }
    }
}