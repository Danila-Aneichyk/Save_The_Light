using LevelControl;
using Player;
using UnityEngine;
using UnityEngine.UI;

public class GameplayScreen : MonoBehaviour
{
    [SerializeField] private Image[] _lightImages;
    private PlayerHp _playerHp;

    private void Awake()
    {
        SetOnLightImages();
        _playerHp = FindObjectOfType<PlayerHp>();
        _playerHp.OnChanged += TakeDamage;
        LevelStateMachine.ResetValues += SetOnLightImages;
    }

    private void SetOnLightImages()
    {
        foreach (Image lightImage in _lightImages)
        {
            lightImage.enabled = true;
        }
    }

    private void TakeDamage(int damage)
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
}