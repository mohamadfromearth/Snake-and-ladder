using UnityEngine;

public class DefaultShortcutFactory : MonoBehaviour, IShortcutFactory
{
    [SerializeField] private DefaultShortcut defaultShortcutPrefab;

    public IShortcut Create() => Instantiate(defaultShortcutPrefab);
}