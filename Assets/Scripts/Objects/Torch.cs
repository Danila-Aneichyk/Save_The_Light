using System;
using Player;
using UnityEngine;

namespace Objects
{
    public class Torch : MonoBehaviour
    {
        private float _maxLightIntensity = 5f;
        private Light _light;
        private PlayerHp _playerHp;

        private void Start()
        {
            _playerHp = GetComponentInParent<PlayerHp>();
            _light = GetComponent<Light>();

            _playerHp.OnApplyDamage += MinusLight;
            _playerHp.OnApplyHeal += PlusLight;
        }

        private void PlusLight()
        {
            _light.intensity = _light.intensity + 0.16f;

            if (_maxLightIntensity < _light.intensity)
            {
                _light.intensity = _maxLightIntensity;
            }
        }

        private void MinusLight()
        {
            _light.intensity = _light.intensity - 0.16f;
        }
    }
}