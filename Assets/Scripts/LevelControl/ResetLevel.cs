using Event_Bus;
using Event_Bus.ActionSignals;
using Player;
using ScoreSystem;
using Service_Locator;
using UnityEngine;

namespace LevelControl
{
    public class ResetLevel : MonoBehaviour
    {
        [Header("Player components")]
        private PlayerHp _playerHp;
        private PlayerMovement _playerMovement;

        [Header("Score statistic")]
        private ScoreStatistics _scoreStatistics;

        [Header("Initial values")]
        [SerializeField] private Transform _initialPosition;
        private int _initialScore = 0;

        public int _score;

        private EventBus _eventBus;

        private void Awake()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>();
            _eventBus.Subscribe<ResetValuesSignal>(ResetLevelValues);

            _playerHp = FindObjectOfType<PlayerHp>();
            _playerMovement = FindObjectOfType<PlayerMovement>();
            _scoreStatistics = FindObjectOfType<ScoreStatistics>();
        }

        private void ResetLevelValues(ResetValuesSignal signal)
        {
            ResetPosition();
            ResetHp();
            ResetScore();
        }

        private void ResetHp()
        {
            _playerHp.CurrentHp = _playerHp.MaxHp;
        }

        private void ResetPosition()
        {
            _playerMovement.transform.position = _initialPosition.transform.position;
        }

        private void ResetScore()
        {
            _scoreStatistics.CurrentScore = _score;
            _scoreStatistics.CurrentScore = _initialScore;
        }
    }
}