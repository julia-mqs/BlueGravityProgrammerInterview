using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePreviewClothes : MonoBehaviour
{
    #region Variables

    [SerializeField] private Image _previewFace;
    [SerializeField] private Image _previewHood;

    #endregion

    #region Methods

    internal void UpdatePreviewFace(Sprite skin)
    {
        _previewFace.sprite = skin;
    }

    internal void UpdatePreviewHood(Sprite skin)
    {
        _previewHood.sprite = skin;
    }

    #endregion
}
