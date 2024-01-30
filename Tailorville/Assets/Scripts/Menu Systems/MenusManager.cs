using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenusManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _storeMenu;
    [SerializeField] private GameObject _wardrobeMenu;
    [Space]
    [SerializeField] private GameObject _inputHUD;
    [SerializeField] private Text _inputText;
    [Space]
    [SerializeField] private AudioSource _bgMusicSource;
    [SerializeField] private AudioClip _villageMusic;
    [SerializeField] private AudioClip _hatShopMusic;
    [SerializeField] private AudioClip _wardrobeMusic;

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
            InputTextUpdater("OPEN HAT SHOP\n(press O)");
        else
            InputTextUpdater("OPEN WARDROBE\n(press O)");
    }

    internal void ShowPickupInput(PickupItemTypeEnum pickup)
    {
        switch (pickup)
        {
            case PickupItemTypeEnum.Crown:
                InputTextUpdater("PICK CROWN\n(press P)");
                break;
            case PickupItemTypeEnum.Diamond:
                InputTextUpdater("PICK DIAMOND\n(press P)");
                break;
            case PickupItemTypeEnum.Hat:
                InputTextUpdater("PICK HAT\n(press P)");
                break;
            case PickupItemTypeEnum.Ring:
                InputTextUpdater("PICK RING\n(press P)");
                break;
            case PickupItemTypeEnum.Scroll:
                InputTextUpdater("PICK SCROLL\n(press P)");
                break;
            default:
                break;
        }
    }

    private void InputTextUpdater(string text)
    {
        ActivateGameObject(_inputHUD);
        _inputText.text = text;
    }

    internal void OpenMenu(MenuTypeEnum menu)
    {
        if (menu == MenuTypeEnum.Store)
        {
            ActivateGameObject(_storeMenu);
            setActiveMenu = ActiveMenu.Store;
            PlaySFX(_hatShopMusic);
        }
        else
        {
            ActivateGameObject(_wardrobeMenu);
            setActiveMenu = ActiveMenu.Wardrobe;
            PlaySFX(_wardrobeMusic);
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
        PlaySFX(_villageMusic);
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

    private void PlaySFX(AudioClip sfx)
    {
        _bgMusicSource.clip = sfx;
        _bgMusicSource.Play();
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