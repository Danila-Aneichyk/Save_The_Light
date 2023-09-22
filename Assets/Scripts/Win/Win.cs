using System;
using LevelControl;
using Names;
using UnityEngine;

namespace Win
{
    public class Win : MonoBehaviour
    {
        private bool _isWin = false;

        private void Awake()
        {
            LevelStateMachine.Instance.OnGameStateChanged += LevelStateMachine_OnGameStateChanged;
        }

        private void LevelStateMachine_OnGameStateChanged(object sender, LevelStates e)
        {
            if (e == LevelStates.LevelEnd)
            {
                StopGameplay();
                ShowWinUI();
            }
        }

        private void StopGameplay()
        {
        }

        private void ShowWinUI()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(Tags.Player))
            {
                _isWin = true;
                LevelStateMachine.Instance.state = LevelStates.LevelEnd;
            }
        }
    }
}