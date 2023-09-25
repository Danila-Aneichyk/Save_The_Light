using Event_Bus;
using Event_Bus.ActionSignals;
using LevelControl;
using Names;
using Player;
using Service_Locator;
using UnityEngine;

namespace Win
{
    public class Win : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private bool _isWin = false;

        private EventBus _eventBus;

        private void Start()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>();
            _eventBus.Subscribe<OnWinLevelSignal>(StopGameplay);
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

        private void StopGameplay(OnWinLevelSignal signal)
        {
            _playerMovement.enabled = false;
        }
    }
}