using Cell;
using Data;
using GameStates;
using Plugins.GridStructure;
using UnityEngine;
using Zenject;
using Grid = GridStructure.Grid;

namespace Di
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameData _gameData;

        // prefabs
        [Header("Prefabs")] [SerializeField] private DefaultCellFactory _defaultCellFactoryPrefab;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private Player _playerPrefab;

        public override void InstallBindings()
        {
            Container.Bind<ICellFactory>().To<DefaultCellFactory>()
                .FromInstance(Instantiate(_defaultCellFactoryPrefab)).AsTransient();

            Container.Bind<CellsPlacer>().To<CellsPlacer>().AsTransient().WithArguments(
                _gameData.row,
                _gameData.column);

            Container.Bind<Player>().FromInstance(Instantiate(_playerPrefab)).AsSingle().NonLazy();
            
            Container.Bind<Grid>().To<SnakeLadderGrid>().AsSingle().WithArguments(_gameData.cellSize, _gameData.row, _gameData.column);
            
            Container.Bind<Dice>().AsTransient();

            Container.Bind<GameStateManager>().AsTransient();

            Container.Bind<ReadyForPlayState>().AsTransient();

            Container.Bind<WaitingForPlayState>().AsTransient();

           

        }
    }
}