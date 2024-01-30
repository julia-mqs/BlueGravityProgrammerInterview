using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInfos : MonoBehaviour
{
    #region Variables

    [SerializeField] private Button _button;
    [Space]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _onHoverSFX;
    [SerializeField] private AudioClip _onClickPositiveSFX;
    [SerializeField] private AudioClip _onClickNegativeSFX;
    [Space]
    [SerializeField] private ItemData _itemData;
    [SerializeField] private Image _itemSprite;
    [SerializeField] private GameObject _redOverlay;
    [SerializeField] private GameObject _goldCoin;
    [SerializeField] private Text _goldCost;
    [Space]
    [SerializeField] private MoneySystem _moneySystem;
    [SerializeField] private AllPlayerItemButtons _allPlayerItemButtons;

    #endregion

    #region Messages

    private void OnEnable()
    {
        Nullchecks();

        if (_itemData == null)
            return;

        if (_button)
            _button.onClick.AddListener(ButtonActionInMenu);

        StartCoroutine(UpdateButtonAfterAFrame());
    }

    private void OnDisable()
    {
        if (_button)
            _button.onClick.RemoveListener(ButtonActionInMenu);
    }

    #endregion

    #region Methods

    private void ButtonActionInMenu()
    {
        if (MenusManager.setActiveMenu == ActiveMenu.Store)
            BuyItem();
        else
        {
            Sprite newSprite = _itemData.ItemSprite;
            PlaySFX(_onClickPositiveSFX);

            switch (_itemData.ItemSlot)
            {
                case ItemSlot.Face:
                    _allPlayerItemButtons._previewClothes.UpdatePreviewFace(newSprite);
                    _allPlayerItemButtons._playerClothes.UpdatePlayerFace(newSprite);
                    break;
                case ItemSlot.Hood:
                    _allPlayerItemButtons._previewClothes.UpdatePreviewHood(newSprite);
                    _allPlayerItemButtons._playerClothes.UpdatePlayerHood(newSprite);
                    break;
                default:
                    break;
            }
        }
    }

    private void BuyItem()
    {
        if (!_itemData.ItemUnlocked && _moneySystem.totalMoney >= _itemData.ItemCost)
        {
            _itemData.UnlockPlayerItem();
            _moneySystem.RemoveMoney(_itemData.ItemCost);
            _allPlayerItemButtons.UpdateAllButtons();
            PlaySFX(_onClickPositiveSFX);
        }
        else
        {
            PlaySFX(_onClickNegativeSFX);
            Debug.Log("Invalid Action (Not enough money or item already unlocked)");
        }
    }

    public void OnSelectButton()
    {
        PlaySFX(_onHoverSFX);
    }

    private void UpdateButton()
    {
        _itemSprite.sprite = _itemData.ItemSprite;

        if (MenusManager.setActiveMenu == ActiveMenu.Store)
            UpdateStoreInfos();
        else
            UpdateWardrobeInfos();
    }

    private IEnumerator UpdateButtonAfterAFrame()
    {
        yield return new WaitForFixedUpdate();

        UpdateButton();
    }

    internal void UpdateStoreInfos()
    {
        if (!_itemData.ItemUnlocked && _moneySystem.totalMoney < _itemData.ItemCost)
            _redOverlay.SetActive(true);
        else
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

    private void PlaySFX(AudioClip sfx)
    {
        _audioSource.clip = sfx;
        _audioSource.Play();
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

        if (_moneySystem == null)
            Debug.Log("Money System script is empty in: " + this.gameObject);

        if (_allPlayerItemButtons == null)
            Debug.Log("All Player Item Buttons script is empty in: " + this.gameObject);
    }

    #endregion
}
