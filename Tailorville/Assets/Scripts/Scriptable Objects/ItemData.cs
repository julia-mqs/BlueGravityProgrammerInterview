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
    [SerializeField] private bool _unlockedByDefault;
    [SerializeField] private ItemSlot _itemSlot;

    #endregion

    #region Properties

    internal int ItemCost => _itemCost;
    internal Sprite ItemSprite => _itemSprite;
    internal bool ItemUnlocked => _itemUnlocked;
    internal ItemSlot ItemSlot => _itemSlot;

    #endregion

    #region Methods

    internal void DataStartup()
    {
        if (_unlockedByDefault)
            UnlockPlayerItem();
        else
            _itemUnlocked = false;
    }

    internal void UnlockPlayerItem()
    {
        _itemUnlocked = true;
    }

    #endregion
}

#region Enum

public enum ItemSlot
{
    Face,
    Hood
}

#endregion