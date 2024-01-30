using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerItemButtons : MonoBehaviour
{
    #region Variables

    [SerializeField] private List<ItemInfos> _allPlayerItemButtons = new List<ItemInfos>();

    [Header("For easy access")]
    [SerializeField] internal UpdatePlayerClothes _playerClothes;
    [SerializeField] internal UpdatePreviewClothes _previewClothes;

    #endregion

    #region Methods

    internal void UpdateAllButtons()
    {
        if (_allPlayerItemButtons != null && _allPlayerItemButtons.Count > 0)
            foreach (var item in _allPlayerItemButtons)
            {
                item.UpdateStoreInfos();
            }
        else
            Debug.Log("All Player Item Buttons List is empty in: " + this.gameObject);
    }

    #endregion
}
