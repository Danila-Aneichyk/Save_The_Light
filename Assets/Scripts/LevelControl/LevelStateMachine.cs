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
                    _eventBus.Invoke(new ShowMainMenuUISignal());
                    state = LevelStates.MainMenu;
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.StartGameplay:
                    //ShowGameplayUI?.Invoke();
                    _eventBus.Invoke(new ShowGameplayUISignal());
                    state = LevelStates.StartGameplay;
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.GameplayInProgress:
                    //StartGameplay?.Invoke();
                    _eventBus.Invoke(new StartGameplaySignal());
                    state = LevelStates.GameplayInProgress;
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.LevelEnd:
                    state = LevelStates.LevelEnd;
                    //OnWinLevel?.Invoke();
                    _eventBus.Invoke(new OnWinLevelSignal());
                    OnGameStateChanged?.Invoke(this, state);
                    break;

                case LevelStates.Death:
                    state = LevelStates.Death;
                    //ShowDeathUI?.Invoke();
                    //ResetValues?.Invoke();
                    _eventBus.Invoke(new ShowDeathUISignal());
                    _eventBus.Invoke(new ResetValuesSignal());
                    OnGameStateChanged?.Invoke(this, state);
                    break;
            }
        }
    }
}