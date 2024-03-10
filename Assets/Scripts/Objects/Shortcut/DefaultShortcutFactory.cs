using UnityEngine;

namespace Objects.Shortcut
{
    public class DefaultShortcutFactory : MonoBehaviour, IShortcutFactory
    {
        [SerializeField] private DefaultShortcut defaultShortcutPrefab;

        public IShortcut Create() => Instantiate(defaultShortcutPrefab);
    }
}