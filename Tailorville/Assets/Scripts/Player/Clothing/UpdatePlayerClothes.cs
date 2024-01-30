using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePlayerClothes : MonoBehaviour
{
    #region Variables

    [SerializeField] private SpriteRenderer _playerFace;
    [SerializeField] private SpriteRenderer _playerHood;

    #endregion

    #region Methods

    internal void UpdatePlayerFace(Sprite skin)
    {
        _playerFace.sprite = skin;
    }

    internal void UpdatePlayerHood(Sprite skin)
    {
        _playerHood.sprite = skin;
    }

    #endregion
}
