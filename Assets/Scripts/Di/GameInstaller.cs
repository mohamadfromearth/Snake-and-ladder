using Cell;
using Data;
using Data.Repositories;
using GameStates;
using Objects.Dice;
using Objects.Shortcut;
using Plugins.GridStructure;
using UnityEngine;
using Zenject;
using Grid = GridStructure.Grid;

namespace Di
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private BoardData boardData;
        [SerializeField] private ShortcutList shortcutList;

        [SerializeField] private GameObject uiParent;

        // prefabs
        [Header("Prefabs")] [SerializeField] private DefaultCellFactory defaultCellFactoryPrefab;
        [SerializeField] private DefaultShortcutFactory defaultShortcutFactoryPrefab;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private DiceController diceController;

        public override void InstallBindings()
        {
            Container.Bind<Grid>().To<SnakeLadderGrid>().AsSingle()
                .WithArguments(boardData.cellSize, boardData.row, boardData.column);

            Container.Bind<IBoardRepository>().To<BoardRepository>().AsSingle()
                .WithArguments(shortcutList);

            Container.Bind<ICellFactory>().To<DefaultCellFactory>()
                .FromInstance(Instantiate(defaultCellFactoryPrefab)).AsTransient();

            Container.Bind<IShortcutFactory>().To<DefaultShortcutFactory>()
                .FromInstance(Instantiate(defaultShortcutFactoryPrefab)).AsTransient();


            Container.Bind<CellsPlacer>().AsTransient().WithArguments(boardData.row, boardData.column);

            Container.Bind<ShortcutPlacer>().AsTransient().WithArguments(shortcutList);

            Container.Bind<IPlacer>().To<Placer>().AsTransient();


            Container.Bind<Player>().FromInstance(Instantiate(playerPrefab)).AsSingle().NonLazy();


            Container.Bind<Dice>().AsTransient();

            Container.Bind<DiceController>().FromInstance(Instantiate(diceController, uiParent.transform)).AsSingle()
                .NonLazy();

            Container.Bind<GameStateManager>().AsTransient();

            Container.Bind<ReadyForPlayState>().AsTransient();

            Container.Bind<WaitingForPlayState>().AsTransient();
        }
    }
}