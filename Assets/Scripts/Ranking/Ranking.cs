using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Ranking : MonoBehaviour
{
    [SerializeField] private RankList _rankList;
    [SerializeField] private RankPanel _rankPanel;
    [SerializeField] private Money _money;

    private Rank _currentRank;
    private int _currentValue;
    private int _leftValue;
    private int _category;
    private int _deposit;
    private int _rankIndex;

    public event UnityAction RankingFinished;

    public void Init()
    {
        _rankIndex = PlayerPrefs.GetInt(Game.RANK_KEY, 0);
        _currentRank = _rankList[_rankIndex];
        
        _category = PlayerPrefs.GetInt(Game.CATEGORY_KEY, 1);
        _currentValue = PlayerPrefs.GetInt(Game.CURRENTRANK_VALUE_KEY, 0);


        _leftValue = _currentRank.CategoryPrice - _currentValue;

        _rankPanel.Init(_currentRank, _category, _currentValue);
    }

    public void Calculate()
    {
        _deposit = _money.GainedMoney;
        Check();
    }

    private void Check()
    {
        if (_deposit <= 0)
        { 
            Save();
            RankingFinished?.Invoke();
            return;
        }
        
        if (_deposit <= _leftValue)
        {
            StartCoroutine(SpendMoney(_deposit));
        }
        else if(_deposit > _leftValue)
        {
            StartCoroutine(SpendMoney(_leftValue));
        }
        
    }

    private IEnumerator SpendMoney(int amount)
    {
        while (amount > 0)
        { 
            amount--;
            _leftValue--;
            _currentValue++;

            if (_leftValue == 0)
            { 
                UpdateCategory();
                _leftValue = _currentRank.CategoryPrice;
                _currentValue = 0;
            }

            _rankPanel.UpdateSlider(_currentRank, _currentValue);

            _deposit--;
            //_rankPanel.UpdateLeftValue(_leftValue);
            _rankPanel.UpdateLeftValue(_currentValue, _currentRank.CategoryPrice);
            yield return new WaitForSeconds(0.05f);
        }

        Check();
    }

    private void UpdateCategory()
    {
        _category++;

        if (_category == 10)
        {
            _category = 1;
            UpdateRank();
        }

        _rankPanel.UpdateCategory(_category, true);
    }

    private void UpdateRank()
    {
        _rankIndex++;

        if (_rankIndex == 10)
            _rankIndex = 0;

        _currentRank = _rankList[_rankIndex];
        _rankPanel.UpdateRank(_currentRank, true);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(Game.RANK_KEY, _rankIndex);
        PlayerPrefs.SetInt(Game.CATEGORY_KEY, _category);
        PlayerPrefs.SetInt(Game.CURRENTRANK_VALUE_KEY, _currentRank.CategoryPrice - _leftValue);
    }
}
