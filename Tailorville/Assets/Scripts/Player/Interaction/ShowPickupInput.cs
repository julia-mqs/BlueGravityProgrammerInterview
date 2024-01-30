using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPickupInput : MonoBehaviour
{
    #region Variables

    [SerializeField] private PickupItemData _pickupItemData;
    [Space]
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private MenusManager _menuManager;
    [SerializeField] private MoneySystem _moneySystem;

    private bool _playerInArea;

    #endregion

    #region Messages

    private void Awake()
    {
        this._playerInArea = false;
    }

    private void Start()
    {
        if (_pickupItemData == null)
        {
            Debug.Log("Pickup Item Data is empty in: " + this.gameObject);
            return;
        }
        if (_spriteRenderer == null)
        {
            Debug.Log("Sprite Renderer is empty in: " + this.gameObject);
            return;
        }

        _spriteRenderer.sprite = _pickupItemData.PickupSprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        if (_pickupItemData == null)
        {
            Debug.Log("Pickup Item Data is empty in: " + this.gameObject);
            return;
        }
        Enabler(this._pickupItemData.PickupItemType);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        Disabler();
    }

    private void Update()
    {
        if (!this._playerInArea)
            return;

        if (_moneySystem == null)
        {
            Debug.Log("Money System object is empty in: " + this.gameObject);
            return;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (_moneySystem)
                _moneySystem.AddMoney(this._pickupItemData.AmountGained);
            else
                Debug.Log("Pickup Item Data is empty in: " + this.gameObject);
            this.gameObject.SetActive(false);
        }
    }

    #endregion

    #region Methods

    private void Enabler(PickupItemTypeEnum type)
    {
        this._playerInArea = true;

        if (_menuManager == null)
        {
            Debug.Log("Menu Manager object is empty in: " + this.gameObject);
            return;
        }
        _menuManager.ShowPickupInput(type);
    }

    private void Disabler()
    {
        this._playerInArea = false;

        if (_menuManager == null)
        {
            Debug.Log("Menu Manager object is empty in: " + this.gameObject);
            return;
        }
        _menuManager.DeactivateInputHUD();
    }

    #endregion
}

#region Enum

public enum PickupItemTypeEnum
{
    Crown,
    Diamond, 
    Hat,
    Ring,
    Scroll
}

#endregion