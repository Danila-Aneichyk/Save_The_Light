using LevelControl;
using ScoreSystem;
using UnityEngine;

namespace Player
{
    public class PlayerDeath : MonoBehaviour
    {
        [SerializeField] private PlayerHp _playerHp;

        private void Awake()
        {
            _playerHp = GetComponent<PlayerHp>();
            _playerHp.PlayerDead += Death;
        }

        private void Death()
        {
            if (_playerHp.CurrentHp <= 0)
            {
                LevelStateMachine.Instance.state = LevelStates.Death;
            }
        }
    }
}