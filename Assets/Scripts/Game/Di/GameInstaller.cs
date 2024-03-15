using Cell;
using Data;
using Data.Repositories;
using Event;
using Game.Event;
using Game.GameStates;
using Game.Objects;
using Game.Objects.Cell;
using Game.Objects.Shortcut;
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
        [SerializeField] private SnakeShortcutFactory snakeShortcutFactoryPrefab;
        [SerializeField] private Player playerPrefab;
        [SerializeField] private DiceController diceController;

        public override void InstallBindings()
        {
            Container.Bind<EventChannel>().AsSingle().NonLazy();
            Container.Bind<EventInstaller>().AsSingle().NonLazy();

            Container.Bind<Grid>().To<SnakeLadderGrid>().AsSingle()
                .WithArguments(boardData.cellSize, boardData.row, boardData.column);

            Container.Bind<IBoardRepository>().To<BoardRepository>().AsSingle()
                .WithArguments(shortcutList);

            Container.Bind<IPlayerRepository>().To<PlayerRepository>().AsSingle().NonLazy();

            Container.Bind<ICellFactory>().To<DefaultCellFactory>()
                .FromInstance(Instantiate(defaultCellFactoryPrefab)).AsTransient();

            Container.Bind<DefaultShortcutFactory>()
                .FromInstance(Instantiate(defaultShortcutFactoryPrefab)).AsTransient();

            Container.Bind<SnakeShortcutFactory>()
                .FromInstance(Instantiate(snakeShortcutFactoryPrefab)).AsTransient();

            Container.Bind<ShortcutFactoryManager>().AsTransient();

            Container.Bind<CellContainer>().AsTransient();

            Container.Bind<CellsPlacer>().AsTransient().WithArguments(boardData.row, boardData.column);

            Container.Bind<ShortcutPlacer>().AsTransient().WithArguments(shortcutList);

            Container.Bind<IPlacer>().To<Placer>().AsTransient();


            Container.Bind<Player>().FromMethod(() =>
                {
                    var player = Instantiate(playerPrefab);
                    player.Channel = Container.Resolve<EventChannel>();
                    return player;
                }
            ).AsSingle().NonLazy();


            Container.Bind<Dice>().AsTransient();

            Container.Bind<DiceController>().FromInstance(Instantiate(diceController, uiParent.transform)).AsSingle()
                .NonLazy();

            Container.Bind<GameStateManager>().AsTransient();

            Container.Bind<ReadyForPlayState>().AsTransient();

            Container.Bind<WaitingForPlayState>().AsTransient();
        }
    }
}