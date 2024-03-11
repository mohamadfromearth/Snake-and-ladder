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

    [SerializeField] private UiManager _uiManager;
    [SerializeField] private float time;
    private CountDownTimer _timer;


    private void Start()
    {
        _timer = new CountDownTimer(time);
        _timer.Play();
        _timer.SetTimeOverListener(OnTimeOver);

        _gameStateManager.Init();

        _gameStateManager.ToState<ReadyForPlayState>();

        _placer.Place();

        _diceController.AddClickListener(DiceClick);

        SetUpPlayerMoveFinishedListener();

        _uiManager.AddRetryListener(OnRetry);
    }


    private void Update()
    {
        _timer.Tick(Time.deltaTime);
        _uiManager.SetTextTime(_timer.GetTimeText());
    }


    private void OnRetry()
    {
        _uiManager.HideGameOverPanel();
        _timer.Restart();
        _player.SetPosition(_boardRepository.GetPositionByIndices(new Vector2Int(0, 0)));
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
            if (CheckWin() == false)
            {
                CheckShortcut();
            }
        });
    }

    private bool CheckWin()
    {
        if (_boardRepository.IsEndOfBoard(_player.transform.position)
            && _timer.IsRunning == false)
        {
            
            return true;
        }

        return false;
    }

    private void CheckShortcut()
    {
        var shortcutPos = _boardRepository.GetShortcutPositionByPosition(_player.transform.position);
        if (shortcutPos != null)
        {
            _player.Move(shortcutPos.Value);
            StartCoroutine(ToReadyForPlayRoutine());
        }
    }

    private IEnumerator ToReadyForPlayRoutine()
    {
        yield return new WaitForSeconds(_player.MoveTime);
        _gameStateManager.ToState<ReadyForPlayState>();
    }

    private void OnTimeOver()
    {
        if (_boardRepository.IsEndOfBoard(_player.transform.position) == false)
        {
            _uiManager.ShowGameOverPanel();
        }
    }
}