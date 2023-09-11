using LevelControl;
using Player;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    [Header("Player components")]
    private PlayerHp _playerHp;
    private PlayerMovement _playerMovement;

    [Header("Initial values")]
    [SerializeField] private Transform _initialPosition;

    private void Awake()
    {
        LevelStateMachine.ResetValues += ResetLevelValues;
        _playerHp = FindObjectOfType<PlayerHp>();
        _playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void ResetLevelValues()
    {
        ResetPosition();
        ResetHp();
    }

    private void ResetHp()
    {
        _playerHp.CurrentHp = _playerHp.MaxHp;
    }

    private void ResetPosition()
    {
        _playerMovement.transform.position = _initialPosition.transform.position;
    }
}