using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;
using Grid = GridStructure.Grid;

namespace Data
{
    [CreateAssetMenu(fileName = "ShortcutList", menuName = "So/ShortcutList")]
    public class ShortcutList : ScriptableObject
    {
        public List<ShortcutData> ShortcutDatas;
    }
}