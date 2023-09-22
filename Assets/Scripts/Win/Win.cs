using System;
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                other.gameObject.GetComponent<PlayerMovement>();
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