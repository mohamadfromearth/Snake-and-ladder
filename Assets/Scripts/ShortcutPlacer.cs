using Data;
using Zenject;

public class ShortcutPlacer : IPlacer
{
     private ShortcutList _shortcutList;
    [Inject] private IShortcutFactory _shortcutFactory;

    public ShortcutPlacer(ShortcutList shortcutList)
    {
        _shortcutList = shortcutList;
    }
    
    public void Place()
    {
        foreach (var shortcutData in _shortcutList.ShortcutDatas)
        {
            var shortcut = _shortcutFactory.Create();
            shortcut.SetData(shortcutData.color, shortcutData.position, shortcutData.rotation, shortcutData.scale);
        }
    }
}