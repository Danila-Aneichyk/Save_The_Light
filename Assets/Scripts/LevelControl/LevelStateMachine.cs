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
                    //ShowMainMenu();
                    _eventBus.Subscribe<ShowMainMenuUISignal>(ShowMainMenu);
                    state = LevelStates.MainMenu;
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.StartGameplay:
                    //ShowGameplayUI?.Invoke();
                    //ShowGameplayUI();
                    _eventBus.Subscribe<ShowGameplayUISignal>(ShowGameplayUI);
                    state = LevelStates.StartGameplay;
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.GameplayInProgress:
                    //StartGameplay?.Invoke();
                    //StartGameplay();
                    _eventBus.Subscribe<StartGameplaySignal>(StartGameplay);
                    state = LevelStates.GameplayInProgress;
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.LevelEnd:
                    state = LevelStates.LevelEnd;
                    //OnWinLevel?.Invoke();
                    // OnWinLevel();
                    _eventBus.Subscribe<OnWinLevelSignal>(OnWinLevel);
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.Death:
                    state = LevelStates.Death;
                    //ShowDeathUI?.Invoke();
                    //ResetValues?.Invoke();
                    //ShowDeathUI();
                    //ResetValues();
                    _eventBus.Subscribe<ShowDeathUISignal>(ShowDeathUI);
                    _eventBus.Subscribe<ResetValuesSignal>(ResetValues);
                    OnGameStateChanged?.Invoke(this, state);
                    break;
            }
        }

        private void ShowMainMenu(ShowMainMenuUISignal signals)
        {
            _eventBus.Invoke(new ShowMainMenuUISignal());
        }

        private void ShowGameplayUI(ShowGameplayUISignal signal)
        {
            _eventBus.Invoke(new ShowGameplayUISignal());
        }

        private void StartGameplay(StartGameplaySignal signal)
        {
            _eventBus.Invoke(new StartGameplaySignal());
        }

        private void OnWinLevel(OnWinLevelSignal signal)
        {
            _eventBus.Invoke(new OnWinLevelSignal());
        }

        private void ShowDeathUI(ShowDeathUISignal signal)
        {
            _eventBus.Invoke(new ShowDeathUISignal());
        }

        private void ResetValues(ResetValuesSignal signal)
        {
            _eventBus.Invoke(new ResetValuesSignal());
        }
    }
}