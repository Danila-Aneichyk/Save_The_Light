using LevelControl;
using Player;
using ScoreSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private Image[] _lightImages;
    [SerializeField] private ScoreStatistics _score;
    [SerializeField] private TextMeshProUGUI _scoreLabel;
    private PlayerHp _playerHp;
    private bool _isLightEnabled = false;

    private void Awake()
    {
        SetOnLightImages();
        _playerHp = FindObjectOfType<PlayerHp>();
        _playerHp.OnApplyDamage += TakeDamage;
        _playerHp.OnApplyHeal += TakeHeal;
        LevelStateMachine.ResetValues += SetOnLightImages;
    }

    private void SetOnLightImages()
    {
        foreach (Image lightImage in _lightImages)
        {
            lightImage.enabled = true;
        }
    }

    private void Update()
    {
        PerformScore();
    }

    private void PerformScore()
    {
        _scoreLabel.text = $"Score: {_score.CurrentScore}";
    }

    private void TakeDamage()
    {
        for (int i = 0; i < _lightImages.Length; i++)
        {
            if (i < _playerHp.CurrentHp)
            {
                _lightImages[i].enabled = true;
            }
            else
            {
                _lightImages[i].enabled = false;
            }
        }
    }

    private void TakeHeal()
    {
        for (int i = 0; i < _lightImages.Length; i++)
        {
            if (i == _playerHp.CurrentHp + 1)
            {
                _lightImages[i].enabled = true;
            }
        }
    }
}