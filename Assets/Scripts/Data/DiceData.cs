using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    
    [CreateAssetMenu(fileName = "DiceData",menuName = "So/DiceData")]
    public class DiceData : ScriptableObject
    {
        public List<String> images;
        private Dictionary<int, string> _diceImageDictionary;

        private void OnEnable()
        {
            _diceImageDictionary = new Dictionary<int, string>();
            int value = 1;
            foreach (var image in images)
            {
                _diceImageDictionary[value] = image;
                value++;
            }
        }

        public string GetImage(int value)
        {
            return _diceImageDictionary[value];
        }
    }
}