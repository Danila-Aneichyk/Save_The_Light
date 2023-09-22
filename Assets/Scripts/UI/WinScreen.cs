using LevelControl;
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

    private void Awake()
    {
        LevelStateMachine.OnWinLevel += ShowWinScreen;
        _retryButton.onClick.AddListener(RetryLevel);
        _homeButton.onClick.AddListener(ToHome);
    }

    private void ShowWinScreen()
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