using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfos : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _button;
    [Space]
    [SerializeField] private ItemData _itemData;
    [SerializeField] private Image _itemSprite;
    [SerializeField] private GameObject _redOverlay;
    [SerializeField] private GameObject _goldCoin;
    [SerializeField] private Text _goldCost;

    #endregion

    #region Messages

    private void Start()
    {
        Nullchecks();

        if (_itemData == null)
            return;

        UpdateButton();
    }

    #endregion

    #region Methods

    private void UpdateButton()
    {
        _itemSprite.sprite = _itemData.ItemSprite;

        if (MenusManager.setActiveMenu == ActiveMenu.Store)
            UpdateStoreInfos();
        else
            UpdateWardrobeInfos();
    }

    private void UpdateStoreInfos()
    {
        //initially...
        _redOverlay.SetActive(false);

        if (_itemData.ItemUnlocked == false)
        {
            _goldCoin.SetActive(true);
            _goldCost.text = _itemData.ItemCost.ToString();
        }
        else
        {
            _goldCoin.SetActive(false);
            _goldCost.text = "SOLD!";
        }
    }

    private void UpdateWardrobeInfos()
    {
        _goldCoin.SetActive(false);

        if (_itemData.ItemUnlocked == false)
        {
            _redOverlay.SetActive(true);
            _goldCost.text = "LOCKED";
        }
        else
        {
            _redOverlay.SetActive(false);
            _goldCost.text = "";
        }
    }

    private void Nullchecks()
    {
        if (_button == null)
            Debug.Log("Button object is empty in: " + this.gameObject);

        if (_itemData == null)
            Debug.Log("Item Data object is empty in: " + this.gameObject);

        if (_redOverlay == null)
            Debug.Log("Red Overlay object is empty in: " + this.gameObject);

        if (_itemSprite == null)
            Debug.Log("Item Sprite object is empty in: " + this.gameObject);

        if (_goldCoin == null)
            Debug.Log("Gold Coin object is empty in: " + this.gameObject);

        if (_goldCost == null)
            Debug.Log("Gold Cost object is empty in: " + this.gameObject);
    }

    #endregion
}
