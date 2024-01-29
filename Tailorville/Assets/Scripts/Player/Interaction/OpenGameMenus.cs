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

        _menuManager.ShowInput(type);
    }

    private void Disabler()
    {
        this._playerInArea = false;

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