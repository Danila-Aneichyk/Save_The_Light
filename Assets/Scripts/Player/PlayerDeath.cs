using LevelControl;
using UnityEngine;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHp _playerHp;

        private void Awake()
        {
            _playerHp = GetComponent<PlayerHp>();
            _playerHp.OnChanged += Death;
        }

        private void Death(int damage)
        {
            if (_playerHp.CurrentHp <= 0)
            {
                LevelStateMachine.Instance.state = LevelStates.Death;
            }
        }
    }
}