using System;
using UnityEngine;

namespace Game.Objects.Shortcut
{
    public class SnakeShortcutFactory : MonoBehaviour, IShortcutFactory
    {
        [SerializeField] private SnakeShortcut shortcutPrefab;

        public IShortcut Create()
        {
            return Instantiate(shortcutPrefab);
        }
    }
}