using System;
using LevelControl;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;

    private void Awake()
    {
        LevelStateMachine.OnWinLevel += ShowWinScreen;
    }

    private void ShowWinScreen()
    {
        _winScreen.SetActive(true);
    }
}