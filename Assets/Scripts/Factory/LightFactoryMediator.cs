using UnityEngine;

namespace Factory
{
    public class LightFactoryMediator : MonoBehaviour
    {
        [Header("Target Factory")]
        private LightFactory _lightFactory;
        [SerializeField] private LightMarker[] _lightMarkers;

        public void Start()
        {
            _lightFactory = GetComponent<LightFactory>();
            _lightFactory.Load();
        }

        private void Update()
        {
            TargetCreating();
        }

        private void TargetCreating()
        {
            foreach (LightMarker lightMarker in _lightMarkers)
            {
                _lightFactory.Create(lightMarker.transform.position);
            }
        }
    }
}