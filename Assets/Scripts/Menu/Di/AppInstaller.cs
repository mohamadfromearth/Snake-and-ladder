using Data.Repositories;
using UnityEngine;
using Zenject;

namespace Menu
{
    public class AppInstaller : MonoInstaller
    {
        // prefabs
        [SerializeField] private DefaultHistoryFactory defaultHistoryFactoryPrefab;

        public override void InstallBindings()
        {
            Container.Bind<IPlayerRepository>().To<PlayerRepository>().AsSingle();

            Container.Bind<IHistoryFactory>().To<DefaultHistoryFactory>().FromInstance(defaultHistoryFactoryPrefab).AsSingle();
            
        }
    }
}