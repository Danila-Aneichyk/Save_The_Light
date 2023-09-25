using UnityEngine;

namespace Factory
{
    public class LightFactory : MonoBehaviour, ILightFactory
    {
        [SerializeField] private Object _healLight;

        private const string HealLight = "Heal Light";

        public void Load()
        {
            _healLight = Resources.Load(HealLight) as GameObject;
        }

        public void Create(LightType lightType, Vector3 lightPosition)
        {
            Instantiate(_healLight, lightPosition, Quaternion.identity);
        }
    }
}