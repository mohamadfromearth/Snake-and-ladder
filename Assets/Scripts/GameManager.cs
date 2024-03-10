using System.Collections;
using Data.Repositories;
using GameStates;
using Objects.Dice;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private IPlacer _placer;
    [Inject] private GameStateManager _gameStateManager;
    [Inject] private Player _player;
    [Inject] private DiceController _diceController;
    [Inject] private IBoardRepository _boardRepository;


    private void Start()
    {
        _gameStateManager.Init();
        _gameStateManager.ToState<ReadyForPlayState>();
        _placer.Place();
        _diceController.AddClickListener(DiceClick);
        SetUpPlayerMoveFinishedListener();
    }


    private void DiceClick()
    {
        _gameStateManager.DiceClick();
        _gameStateManager.ToState<WaitingForPlayState>();
    }

    private void SetUpPlayerMoveFinishedListener()
    {
        _player.AddMoveFinishedListener(() =>
        {
            var shortcutPos = _boardRepository.GetShortcutPositionByPosition(_player.transform.position);
            if (shortcutPos != null)
            {
                Debug.Log("pos: " + shortcutPos.Value);
                _player.Move(shortcutPos.Value);
                StartCoroutine(ToReadyForPlayRoutine());
            }
            else
            {
                _gameStateManager.ToState<ReadyForPlayState>();
            }
        });
    }

    private IEnumerator ToReadyForPlayRoutine()
    {
        yield return new WaitForSeconds(_player.MoveTime);
        _gameStateManager.ToState<ReadyForPlayState>();
    }
}