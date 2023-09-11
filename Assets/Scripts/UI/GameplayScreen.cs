using System;
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
    [SerializeField] private int _amountOfHearts;
    [SerializeField] private Sprite FullHeart;
    [SerializeField] private Sprite EmptyHeart;

    private void Awake()
    {
        SetOnLightImages();
        _playerHp = FindObjectOfType<PlayerHp>();
        //  _playerHp.OnApplyDamage += TakeDamage;
        //  _playerHp.OnApplyHeal += TakeHeal;
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
        ControlLightAmount();
    }

    private void ControlLightAmount()
    {
        int healthPoints = _playerHp.CurrentHp;
        if (healthPoints > _playerHp.CurrentHp)
        {
            healthPoints = _amountOfHearts;
        }

        for (int i = 0; i < _lightImages.Length; i++)
        {
            _lightImages[i].sprite = i < Mathf.RoundToInt(healthPoints) ? FullHeart : EmptyHeart;

            _lightImages[i].enabled = i < _amountOfHearts;
        }
    }

    private void PerformScore()
    {
        _scoreLabel.text = $"Score: {_score.CurrentScore}";
    }

    /*private void TakeDamage()
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
            if (i > _playerHp.CurrentHp)
            {
                _lightImages[i].enabled = true;
            }

            if (i > _playerHp.CurrentHp)
            {
                _lightImages[i].enabled = true;
            }
        }
    }*/
}