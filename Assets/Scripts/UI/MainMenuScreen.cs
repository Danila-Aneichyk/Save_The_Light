using Names;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _questionButton;
    [SerializeField] private Button _OkButton;

    [Header("Components to open")]
    [SerializeField] private GameObject _questionWindow;

    private void Awake()
    {
        _startButton.onClick.AddListener(LoadGameplayScene);
        _questionButton.onClick.AddListener(OpenQuestionWindow);
        _OkButton.onClick.AddListener(CloseQuestionWindow);
    }

    private void LoadGameplayScene()
    {
        SceneManager.LoadScene(SceneIndexes.Gameplay);
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