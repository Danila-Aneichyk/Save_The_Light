using System;
using Player;
using UnityEngine;

namespace Objects
{
    public class Torch : MonoBehaviour
    {
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
        }

        private void MinusLight()
        {
            _light.intensity = _light.intensity - 0.16f;
        }
    }
}