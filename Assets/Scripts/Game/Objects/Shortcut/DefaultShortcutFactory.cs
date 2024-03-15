using Objects.Shortcut;
using UnityEngine;

namespace Game.Objects.Shortcut
{
    public class DefaultShortcutFactory : MonoBehaviour, IShortcutFactory
    {
      [SerializeField] private ShortCut shortCutPrefab;

        public IShortcut Create() => Instantiate(shortCutPrefab);
    }
}