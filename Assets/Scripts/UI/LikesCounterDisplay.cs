using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Collections;

public class LikesCounterDisplay : MonoBehaviour
{
    [SerializeField] private Transform _likeIcon;
    [SerializeField] private TMP_Text _likesCountDisplay;
    [SerializeField] private Money _money;

    private void OnEnable()
    {
        _money.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _money.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int old, int current)
    {
        _likesCountDisplay.text = current.ToString();
    }

}
