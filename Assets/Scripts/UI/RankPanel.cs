using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class RankPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _rankNameDisplay;
    [SerializeField] private TMP_Text _categoryDisplay;
    [SerializeField] private TMP_Text _leftForNextCategory;
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform _categoryIcon;

    public void Init(Rank currentRank, int category, int leftValue)
    {
        UpdateRank(currentRank);
        UpdateLeftValue(leftValue, currentRank.CategoryPrice);
        UpdateCategory(category);
        UpdateSlider(currentRank, leftValue);
    }

    public void UpdateRank(Rank rank, bool needEffect = false)
    {
        _rankNameDisplay.text = rank.Name;
        _rankNameDisplay.color = rank.Color;

        if (needEffect)
            _rankNameDisplay.transform.DOPunchScale(Vector3.one * 0.3f, 0.5f, 8);
    }

    public void UpdateCategory(int category, bool needEffect = false)
    {
        _categoryDisplay.text = category.ToString();

        if (needEffect)
            _categoryIcon.DOPunchScale(Vector3.one * 0.3f, 0.5f, 8);
    }

    public void UpdateLeftValue(int amount, int max)
    {
        //_leftForNextCategory.text = $"Left: {amount.ToString()}";
        _leftForNextCategory.text = $"{amount.ToString()}/{max.ToString()}";
    }

    public void UpdateSlider(Rank rank, float currentValue)
    { 
        //_slider.maxValue = rank.CategoryPrice;
        _slider.value = currentValue / rank.CategoryPrice;
    }
}
