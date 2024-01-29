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

    #endregion

    #region Messages

    private void Awake()
    {
        Nullchecks();

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
            ActivateGameObject(_storeMenu);
        else
            ActivateGameObject(_wardrobeMenu);

        PlayerMovement.setGameMode = GameMode.InMenu;
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

        PlayerMovement.setGameMode = GameMode.Playing;
    }

    internal void DeactivateInputHUD()
    {
        DeactivateGameObject(_inputHUD);
    }

    private void Nullchecks()
    {
        if (_storeMenu == null)
            Debug.Log("Store Menu obeject is empty in: " + this.gameObject);

        if (_wardrobeMenu == null)
            Debug.Log("Wardrobe Menu obeject is empty in: " + this.gameObject);

        if (_inputHUD == null)
            Debug.Log("Input HUD obeject is empty in: " + this.gameObject);

        if (_inputText == null)
            Debug.Log("Input Text obeject is empty in: " + this.gameObject);
    }

    #endregion
}
