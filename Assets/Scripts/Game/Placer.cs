using System.Collections.Generic;
using Game.Objects.Cell;
using Game.Objects.Shortcut;
using Zenject;

public class Placer : IPlacer
{
    [Inject] private CellsPlacer _cellsPlacer;
    [Inject] private ShortcutPlacer _shortcutPlacer;

    private List<IPlacer> _placers;

    private void InitPlacers()
    {
        _placers = new List<IPlacer>()
        {
            _cellsPlacer,
            _shortcutPlacer
        };
    }


    public void Place()
    {
        InitPlacers();
        foreach (var placer in _placers)
        {
            placer.Place();
        }
    }
}