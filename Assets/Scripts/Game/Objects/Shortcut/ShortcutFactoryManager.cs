using System.Collections.Generic;
using Data.Board;
using Zenject;

namespace Game.Objects.Shortcut
{
    public class ShortcutFactoryManager
    {
        private Dictionary<int, IShortcutFactory> _shortcutsFactories = new();

        [Inject]
        private void Construct(DefaultShortcutFactory defaultShortcutFactory, SnakeShortcutFactory snakeShortcutFactory)
        {
            _shortcutsFactories[(int)ShortcutType.Ladder] = defaultShortcutFactory;
            _shortcutsFactories[(int)ShortcutType.Snake] = snakeShortcutFactory;
        }

        public IShortcutFactory GetShortcutFactory(ShortcutType shortcutType)
        {
            return _shortcutsFactories[(int)shortcutType];
        }
    }
}