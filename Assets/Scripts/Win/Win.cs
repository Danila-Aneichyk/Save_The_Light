using LevelControl;
using Names;
using Player;
using UnityEngine;

namespace Win
{
    public class Win : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private bool _isWin = false;

        private void Awake()
        {
            LevelStateMachine.OnWinLevel += StopGameplay;
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject.CompareTag(Tags.Player))
            {
                _playerMovement = col.gameObject.GetComponentInParent<PlayerMovement>();
                _isWin = true;
                LevelStateMachine.Instance.state = LevelStates.LevelEnd;
            }
        }

        private void StopGameplay()
        {
            _playerMovement.enabled = false;
        }
    }
}