using LevelControl;
using ScoreSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _homeButton;

    [Header("Components")]
    [SerializeField] private GameObject _mainMenuScreen;
    [SerializeField] private GameObject _deathScreen;
    [SerializeField] private TextMeshProUGUI _scoreLabel;
    private ResetLevel _resetLevel;

    private void Awake()
    {
        LevelStateMachine.ShowDeathUI += ShowDeathScreen;
        _resetLevel = FindObjectOfType<ResetLevel>();
        _retryButton.onClick.AddListener(RetryLevel);
        _homeButton.onClick.AddListener(ToHome);
    }

    private void ShowDeathScreen()
    {
        _deathScreen.SetActive(true);
        ShowScoreText();
    }

    private void RetryLevel()
    {
        LevelStateMachine.Instance.state = LevelStates.StartGameplay;
        _deathScreen.SetActive(false);
    }

    private void ToHome()
    {
        LevelStateMachine.Instance.state = LevelStates.MainMenu;
        _mainMenuScreen.SetActive(true);
        _deathScreen.SetActive(false);
    }

    private void ShowScoreText()
    {
        _scoreLabel.text = $"Score: {_resetLevel._score.ToString()}";
    }
}