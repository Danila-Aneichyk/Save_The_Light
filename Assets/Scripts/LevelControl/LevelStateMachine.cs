using System;
using Event_Bus;
using Event_Bus.ActionSignals;
using Service_Locator;
using UnityEngine;

namespace LevelControl
{
    public class LevelStateMachine : MonoBehaviour
    {
        public static LevelStateMachine Instance { get; private set; }

        public LevelStates state;
        public event EventHandler<LevelStates> OnGameStateChanged;

        private EventBus _eventBus;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _eventBus = ServiceLocator.Current.Get<EventBus>();
            state = LevelStates.MainMenu;
            OnGameStateChanged?.Invoke(this, state);
        }

        private void Update()
        {
            switch (state)
            {
                case LevelStates.MainMenu:
                    //ShowMainMenuUI?.Invoke();
                    ShowMainMenu();
                    state = LevelStates.MainMenu;
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.StartGameplay:
                    //ShowGameplayUI?.Invoke();
                    ShowGameplayUI();
                    state = LevelStates.StartGameplay;
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.GameplayInProgress:
                    //StartGameplay?.Invoke();
                    StartGameplay();
                    state = LevelStates.GameplayInProgress;
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.LevelEnd:
                    state = LevelStates.LevelEnd;
                    //OnWinLevel?.Invoke();
                    OnWinLevel();
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.Death:
                    state = LevelStates.Death;
                    //ShowDeathUI?.Invoke();
                    //ResetValues?.Invoke();
                    ShowDeathUI();
                    ResetValues();
                    OnGameStateChanged?.Invoke(this, state);
                    break;
            }
        }

        private void ShowMainMenu()
        {
            _eventBus.Invoke(new ShowMainMenuUISignal());
        }

        private void ShowGameplayUI()
        {
            _eventBus.Invoke(new ShowGameplayUISignal());
        }

        private void StartGameplay()
        {
            _eventBus.Invoke(new StartGameplaySignal());
        }

        private void OnWinLevel()
        {
            _eventBus.Invoke(new OnWinLevelSignal());
        }

        private void ShowDeathUI()
        {
            _eventBus.Invoke(new ShowDeathUISignal());
        }

        private void ResetValues()
        {
            _eventBus.Invoke(new ResetValuesSignal());
        }
    }
}