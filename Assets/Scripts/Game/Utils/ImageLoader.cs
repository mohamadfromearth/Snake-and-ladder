using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;


public class ImageLoader : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private SpriteAtlas _spriteAtlas;


    public void LoadImage(string name)
    {
        _image.sprite = _spriteAtlas.GetSprite(name);
    }

    public void LoadImage(Image image, string name)
    {
        image.sprite = _spriteAtlas.GetSprite(name);
    }
}