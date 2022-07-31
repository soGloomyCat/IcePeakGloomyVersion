using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SurvivalPanel : MonoBehaviour
{
    [SerializeField] private SurvivalUIItem _itemTemplate;
    [SerializeField] private float _baseDelay = 0.3f;

    private List<SurvivalUIItem> _items = new List<SurvivalUIItem>();

    public void Init(Survivals survivals)
    {
        for (int i = 0; i < survivals.Count; i++)
        {
            Survival survival = survivals[i];
            survival.Saved += OnSave;
            SurvivalUIItem survivalUIItem = Instantiate(_itemTemplate, transform);
            _items.Add(survivalUIItem);
            survivalUIItem.Init(_baseDelay * i);
        }
    }

    private void OnSave(Survival survival)
    { 
        survival.Saved -= OnSave;
        SurvivalUIItem freeItem = _items.FirstOrDefault((item) => item.IsUsed == false);
        freeItem.Activate(survival.Icon);
    }
}
