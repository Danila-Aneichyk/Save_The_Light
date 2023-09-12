using Objects;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreStatistics : MonoBehaviour
    {
        public float CurrentScore;
        private int _scoreBonus = 15;
        private float _scorePerSecond = 0.01f;

        private void Start()
        {
            HealLight.OnScoreChanged += AddScoreBonus;
        }

        private void Update()
        {
            AddScore();
        }

        private void AddScoreBonus()
        {
            CurrentScore += _scoreBonus;
        }

        private void AddScore()
        {
            CurrentScore += _scorePerSecond;
        }
    }
}