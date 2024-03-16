using UnityEngine;

namespace Game.Objects.Shortcut
{
    public class ShortCut : MonoBehaviour, IShortcut
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void SetData(Color color, Vector3 position, Vector3 rotation, Vector3 scale)
        {
            spriteRenderer.color = color;
            transform.position = position;
            transform.rotation = Quaternion.Euler(rotation);
            transform.localScale = scale;
        }
    }
}