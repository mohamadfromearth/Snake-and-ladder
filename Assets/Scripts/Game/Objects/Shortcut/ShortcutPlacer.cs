using Data;
using Zenject;

namespace Game.Objects.Shortcut
{
    public class ShortcutPlacer : IPlacer
    {
        private ShortcutList _shortcutList;
        [Inject] private ShortcutFactoryManager _shortcutFactoryManager;

        public ShortcutPlacer(ShortcutList shortcutList)
        {
            _shortcutList = shortcutList;
        }
    
        public void Place()
        {
            foreach (var shortcutData in _shortcutList.ShortcutDatas)
            {
                var shortcut = _shortcutFactoryManager.GetShortcutFactory(shortcutData.shortcutType).Create();
                shortcut.SetData(shortcutData.color, shortcutData.position, shortcutData.rotation, shortcutData.scale);
            }
        }
    }
}