using UnityEngine;

namespace Objects.Shortcut
{
    public class DefaultShortcut : MonoBehaviour, IShortcut
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