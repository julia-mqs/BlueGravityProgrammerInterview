using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGameMenus : MonoBehaviour
{
    #region Variables

    [SerializeField] private MenuTypeEnum _menuType;
    [SerializeField] private MenusManager _menuManager;

    private bool _playerInArea;

    #endregion

    #region Messages

    private void Awake()
    {
        this._playerInArea = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }

        Enabler(this._menuType);
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

        if (_menuManager == null)
        {
            Debug.Log("Menu Manager object is empty in: " + this.gameObject);
            return;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            _menuManager.OpenMenu(this._menuType);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            _menuManager.DeactivateAllGameMenus();
        }
    }

    #endregion

    #region Methods

    private void Enabler(MenuTypeEnum type)
    {
        this._playerInArea = true;

        if (_menuManager == null)
        {
            Debug.Log("Menu Manager object is empty in: " + this.gameObject);
            return;
        }
        _menuManager.ShowInput(type);
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

public enum MenuTypeEnum
{
    Store,
    Wardrobe
}

#endregion