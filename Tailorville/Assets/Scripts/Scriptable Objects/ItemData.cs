using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    #region Variables

    [SerializeField] private int _itemCost;
    [SerializeField] private Sprite _itemSprite;
    [SerializeField] private bool _itemUnlocked;

    #endregion

    #region Properties

    internal float ItemCost => _itemCost;
    internal Sprite ItemSprite => _itemSprite;
    internal bool ItemUnlocked => _itemUnlocked;

    #endregion
}

