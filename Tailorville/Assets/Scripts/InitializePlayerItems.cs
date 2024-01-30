using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePlayerItems : MonoBehaviour
{
    #region Variables

    [SerializeField] private List<ItemData> _allPlayerItems = new List<ItemData>();

    #endregion

    #region Messages

    private void Start()
    {
        if (_allPlayerItems != null && _allPlayerItems.Count > 0)
            foreach (var item in _allPlayerItems)
            {
                item.DataStartup();
            }
        else
            Debug.Log("All Player Items List is empty in: " + this.gameObject);
    }

    #endregion
}
