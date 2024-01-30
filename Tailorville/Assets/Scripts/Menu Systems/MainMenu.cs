using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Variables

    [SerializeField] private string _mainScene;

    #endregion

    #region Messages

    private void Update()
    {
        if (Input.anyKeyDown && _mainScene != null)
        {
            SceneManager.LoadScene(_mainScene.ToString());
        }
    }

    #endregion
}
