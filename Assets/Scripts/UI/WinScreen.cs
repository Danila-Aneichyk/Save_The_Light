using Event_Bus;
using Event_Bus.ActionSignals;
using LevelControl;
using Service_Locator;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [Header("Screens")]
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _mainMenuScreen;

    [Header("Buttons")]
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _homeButton;

    private EventBus _eventBus;

    private void Awake()
    {
        _retryButton.onClick.AddListener(RetryLevel);
        _homeButton.onClick.AddListener(ToHome);
    }

    private void Start()
    {
        _eventBus = ServiceLocator.Current.Get<EventBus>();
        _eventBus.Subscribe<OnWinLevelSignal>(ShowWinScreen);
    }

    private void ShowWinScreen(OnWinLevelSignal signal)
    {
        _winScreen.SetActive(true);
    }

    private void RetryLevel()
    {
        LevelStateMachine.Instance.state = LevelStates.StartGameplay;
        _winScreen.SetActive(false);
    }

    private void ToHome()
    {
        LevelStateMachine.Instance.state = LevelStates.MainMenu;
        _mainMenuScreen.SetActive(true);
        _winScreen.SetActive(false);
    }
}