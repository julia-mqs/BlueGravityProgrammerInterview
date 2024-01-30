using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnEnable : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject _selectOnEnable;

    #endregion

    #region Messages

    private void OnEnable()
    {
        if (_selectOnEnable != null)
            EventSystem.current.SetSelectedGameObject(_selectOnEnable);
        else
            Debug.Log("Select On Enable object is empty in: " + this.gameObject);
    }

    #endregion
}
