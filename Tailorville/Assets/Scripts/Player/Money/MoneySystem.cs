using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    #region Variables

    [SerializeField] private Text _moneyText;
    [SerializeField] private Text _addedMoneyFeedback;

    private IEnumerator _removeFeedback;
    internal int totalMoney { get; private set; }

    #endregion

    #region Messages

    private void Start()
    {
        UpdateMoney();
        ShowMoneyFeedback(false);
        _removeFeedback = null;
    }

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddMoney(30);
        }
    }

    #region Methods

    private void UpdateMoney()
    {
        if (_moneyText == null)
        {
            Debug.Log("Money Text object is empty in: " + this.gameObject);
            return;
        }
        _moneyText.text = totalMoney.ToString("D4");
    }

    private void ShowMoneyFeedback(bool show, int amount = 0)
    {
        if (_addedMoneyFeedback == null)
        {
            Debug.Log("Added Money Feedback object is empty in: " + this.gameObject);
            return;
        }

        if (show == false)
        {
            _addedMoneyFeedback.gameObject.SetActive(false);
            return;
        }
        else
        {
            _addedMoneyFeedback.gameObject.SetActive(true);
            _addedMoneyFeedback.text = string.Concat("+", amount);
            CallRemoveFeedback();
        }
    }

    internal void AddMoney(int amount)
    {
        totalMoney += amount;
        UpdateMoney();
        ShowMoneyFeedback(true, amount);
    }

    internal void RemoveMoney(int amount)
    {
        totalMoney -= amount;
        UpdateMoney();
        ShowMoneyFeedback(true, amount);
    }

    private IEnumerator RemoveMoneyFeedback()
    {
        yield return new WaitForSeconds(1f);
        ShowMoneyFeedback(false);
    }

    private void AssignCoroutineToVariable()
    {
        _removeFeedback = RemoveMoneyFeedback();
        StartCoroutine(_removeFeedback);
    }

    private void CallRemoveFeedback()
    {
        if (_removeFeedback == null)
        {
            AssignCoroutineToVariable();
        }
        else
        {
            StopCoroutine(_removeFeedback);
            _removeFeedback = null;
            AssignCoroutineToVariable();
        }
    }

    #endregion
}
