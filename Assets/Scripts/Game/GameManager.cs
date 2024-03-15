using System.Collections;
using Data;
using Data.Repositories;
using Event;
using Event.EventsData;
using Game.GameStates;
using Game.Objects;
using GameStates;
using Objects.Dice;
using Ui;
using UnityEngine;
using Utils;
using Zenject;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        [Inject] private IPlacer _placer;
        [Inject] private GameStateManager _gameStateManager;
        [Inject] private Player _player;
        [Inject] private EventChannel _eventChannel;
        [Inject] private DiceController _diceController;
        [Inject] private IBoardRepository _boardRepository;
        [Inject] private IPlayerRepository _playerRepository;

        [SerializeField] private UiManager uiManager;

        [SerializeField] private float time;
        private CountDownTimer _timer;

        private ScoreCalculator _scoreCalculator;


        private void Start()
        {
            _timer = new CountDownTimer(time);
            _timer.Play();
            _timer.SetTimeOverListener(OnTimeOver);

            _gameStateManager.Init();

            _gameStateManager.ToState<ReadyForPlayState>();

            _placer.Place();

            _diceController.AddClickListener(DiceClick);


            uiManager.AddRetryListener(OnRetry);
            uiManager.AddReplayListener(OnReplay);

            _scoreCalculator = new ScoreCalculator(time);

            _eventChannel.Subscribe<PlayerMoveFinishedEventData>(OnPlayerMoveFinished);
        }

        private void OnDisable()
        {
            uiManager.RemoveRetryListener(OnRetry);
            uiManager.RemoveReplayListener(OnReplay);

            _eventChannel.UnSubscribe<PlayerMoveFinishedEventData>(OnPlayerMoveFinished);
        }


        private void Update()
        {
            _timer.Tick(Time.deltaTime);
            uiManager.SetTextTime(_timer.GetTimeText());

            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log(_gameStateManager.CurrentStateType);
            }
        }


        private void OnRetry()
        {
            uiManager.HideGameOverPanel();
            _timer.Restart();
            _player.SetPosition(_boardRepository.GetPositionByIndices(new Vector2Int(0, 0)));
        }

        private void OnReplay()
        {
            uiManager.HideWinPanel();
            _timer.Restart();
            _player.SetPosition(_boardRepository.GetPositionByIndices(new Vector2Int(0, 0)));
            _gameStateManager.ToState<ReadyForPlayState>();
        }


        private void DiceClick()
        {
            _gameStateManager.DiceClick();
        }

        private void OnPlayerMoveFinished()
        {
            if (CheckWin() == false)
            {
                if (CheckShortcut() == false)
                {
                    Debug.Log("Player move finsihed shortcut false");

                    _gameStateManager.ToState<ReadyForPlayState>();
                }
            }
        }

        private bool CheckWin()
        {
            if (IsWon())
            {
                var score = _scoreCalculator.CalculateScore(_timer.CurrentTime);
                var starsCount = _scoreCalculator.CalculateStarsCount(_timer.CurrentTime);

                _playerRepository.SavePlayerScore(new PlayerScore(
                    score,
                    _timer.CurrentTime,
                    _timer.GetTimeText(),
                    starsCount
                ));

                uiManager.ShowWinPanel(starsCount, "Score: " + score, "Time: " + _timer.GetTimeText());

                return true;
            }

            return false;
        }

        private bool IsWon()
        {
            return _boardRepository.IsEndOfBoard(_player.transform.position)
                   && _timer.IsRunning;
        }

        private bool CheckShortcut()
        {
            var shortcutPos = _boardRepository.GetShortcutPositionByPosition(_player.transform.position);
            if (shortcutPos != null)
            {
                _player.Move(shortcutPos.Value);
                StartCoroutine(ToReadyForPlayRoutine());
                return true;
            }

            return false;
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
                uiManager.ShowGameOverPanel();
            }
        }
    }
}