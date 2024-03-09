using System;
using Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    [SerializeField] private ImageLoader _imageLoader;
    [SerializeField] private DiceData _diceData;
    [SerializeField] private Button _button;



    public void AddClickListener(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }
    
    
    public void SetImage(int value)
    {
        _imageLoader.LoadImage(_diceData.GetImage(value));
    }



}
