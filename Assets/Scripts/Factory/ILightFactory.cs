using UnityEngine;

namespace Factory
{
    public interface ILightFactory
    {
        public void Load();
        public void Create(LightType lightType, Vector3 lightPosition);
    }
}