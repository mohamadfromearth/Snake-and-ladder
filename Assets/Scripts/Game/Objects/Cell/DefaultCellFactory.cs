using UnityEngine;

namespace Game.Objects.Cell
{
    public class DefaultCellFactory : MonoBehaviour, ICellFactory
    {
        [SerializeField] private DefaultCell _defaultCellPrefab;

        public ICell Create() => Instantiate(_defaultCellPrefab, transform);
    }
}