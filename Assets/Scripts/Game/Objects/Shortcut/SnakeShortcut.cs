using Objects.Shortcut;
using UnityEngine;

namespace Game.Objects.Shortcut
{
    public class SnakeShortcut : MonoBehaviour, IShortcut
    {
        [SerializeField] private GameObject snakeFacePrefab;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetData(Color color, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            var snakeFace = Instantiate(snakeFacePrefab);
            spriteRenderer.color = color;
            transform.position = position;
            transform.localScale = scale;
            snakeFace.transform.SetParent(transform);
            snakeFace.transform.position = new Vector3(position.x, position.y + scale.y - 1, 0f);
            transform.rotation = Quaternion.Euler(rotation);
        }
    }
}