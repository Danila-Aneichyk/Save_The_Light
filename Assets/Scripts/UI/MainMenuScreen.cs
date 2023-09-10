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

    private void Awake()
    {
        _startButton.onClick.AddListener(LoadGameplayScene);
        _questionButton.onClick.AddListener(OpenQuestionWindow);
        _OkButton.onClick.AddListener(CloseQuestionWindow);
    }

    private void LoadGameplayScene()
    {
        _mainMenuScreen.SetActive(false);
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