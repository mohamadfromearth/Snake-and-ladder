using Cell;
using Data;
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

        public override void InstallBindings()
        {
            Container.Bind<ICellFactory>().To<DefaultCellFactory>()
                .FromInstance(Instantiate(_defaultCellFactoryPrefab)).AsTransient();

            Container.Bind<CellsPlacer>().To<CellsPlacer>().AsTransient().WithArguments(
                _gameData.row,
                _gameData.column);

            Container.Bind<Grid>().To<Grid>().AsTransient().WithArguments(_gameData.cellSize, _gameData.row, _gameData.column);
        }
    }
}