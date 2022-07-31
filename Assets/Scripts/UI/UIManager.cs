using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] private SurvivalPanel _survivalPanel;
    [SerializeField] private Transform _finishPanel;

    private void Awake()
    {
        _finishPanel.localScale = Vector3.zero;    
    }

    public void Init(Survivals survivals)
    {
        _survivalPanel.Init(survivals);
    }

    public void OnLevelFiinsh()
    {
        _finishPanel.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }
}
