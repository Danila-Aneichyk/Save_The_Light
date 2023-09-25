using Event_Bus;
using Event_Bus.ActionSignals;
using LevelControl;
using Service_Locator;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _questionButton;
    [SerializeField] private Button _OkButton;

    [Header("Components to open")]
    [SerializeField] private GameObject _questionWindow;
    [SerializeField] private GameObject _mainMenuScreen;

    private EventBus _eventBus;

    private void Awake()
    {
        _eventBus = ServiceLocator.Current.Get<EventBus>();

        _eventBus.Subscribe<ShowMainMenuUISignal>(OpenMainMenu);
        LevelStateMachine.Instance.state = LevelStates.MainMenu;

        _startButton.onClick.AddListener(LoadGameplayScene);
        _questionButton.onClick.AddListener(OpenQuestionWindow);
        _OkButton.onClick.AddListener(CloseQuestionWindow);
    }

    private void OpenMainMenu(ShowMainMenuUISignal signal)
    {
        _mainMenuScreen.SetActive(true);
    }

    private void LoadGameplayScene()
    {
        _mainMenuScreen.SetActive(false);
        LevelStateMachine.Instance.state = LevelStates.StartGameplay;
    }

    private void OpenQuestionWindow()
    {
        _questionWindow.SetActive(true);
    }

    private void CloseQuestionWindow()
    {
        _questionWindow.SetActive(false);
    }
}