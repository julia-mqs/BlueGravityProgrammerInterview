using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class PickupItemData : ScriptableObject
{
    #region Variables

    [SerializeField] private PickupItemTypeEnum _pickupItemType;
    [SerializeField] private int _amountGained;
    [SerializeField] private Sprite _pickupSprite;

    #endregion

    #region Properties

    internal PickupItemTypeEnum PickupItemType => _pickupItemType;
    internal int AmountGained => _amountGained;
    internal Sprite PickupSprite => _pickupSprite;

    #endregion
}