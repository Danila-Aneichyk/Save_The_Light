using UnityEngine;

namespace Factory
{
    public class LightMarker : MonoBehaviour
    {
        public LightType LightType;
        private float _radius = 1f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, _radius);
            Gizmos.color = Color.white;
        }
    }
}