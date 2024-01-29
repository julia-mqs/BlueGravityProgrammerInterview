using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenusManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _storeMenu;
    [SerializeField] private GameObject _wardrobeMenu;

    [SerializeField] private GameObject _inputHUD;
    [SerializeField] private Text _inputText;

    public static GameMode setGameMode { get; private set; }
    public static ActiveMenu setActiveMenu { get; private set; }

    #endregion

    #region Messages

    private void Awake()
    {
        Nullchecks();
        setGameMode = GameMode.Playing;

        DeactivateAllGameMenus();
        DeactivateInputHUD();
    }

    #endregion

    #region Methods

    internal void ShowInput(MenuTypeEnum menu)
    {
        if (menu == MenuTypeEnum.Store)
        {
            ActivateGameObject(_inputHUD);
            _inputText.text = "OPEN STORE\n(press O)";
        }
        else
        {
            ActivateGameObject(_inputHUD);
            _inputText.text = "OPEN WARDROBE\n(press O)";
        }
    }

    internal void OpenMenu(MenuTypeEnum menu)
    {
        if (menu == MenuTypeEnum.Store)
        {
            ActivateGameObject(_storeMenu);
            setActiveMenu = ActiveMenu.Store;
        }
        else
        {
            ActivateGameObject(_wardrobeMenu);
            setActiveMenu = ActiveMenu.Wardrobe;
        }

        setGameMode = GameMode.InMenu;
    }

    private void ActivateGameObject(GameObject theObject)
    {
        if (theObject)
            theObject.SetActive(true);
    }

    private void DeactivateGameObject(GameObject theObject)
    {
        if (theObject)
            theObject.SetActive(false);
    }

    internal void DeactivateAllGameMenus()
    {
        DeactivateGameObject(_storeMenu);
        DeactivateGameObject(_wardrobeMenu);

        setGameMode = GameMode.Playing;
    }

    internal void DeactivateInputHUD()
    {
        DeactivateGameObject(_inputHUD);
    }

    private void Nullchecks()
    {
        if (_storeMenu == null)
            Debug.Log("Store Menu object is empty in: " + this.gameObject);

        if (_wardrobeMenu == null)
            Debug.Log("Wardrobe Menu object is empty in: " + this.gameObject);

        if (_inputHUD == null)
            Debug.Log("Input HUD object is empty in: " + this.gameObject);

        if (_inputText == null)
            Debug.Log("Input Text object is empty in: " + this.gameObject);
    }

    #endregion
}

#region Enums

public enum ActiveMenu
{
    Store,
    Wardrobe
}

public enum GameMode
{
    Playing,
    InMenu
}

#endregion