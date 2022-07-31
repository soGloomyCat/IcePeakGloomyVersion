using UnityEngine;

public class TargetArrowsHandler : MonoBehaviour
{
    [SerializeField] private Transform _arrowsCanvas;
    [SerializeField] private TargetIndicator _targetIndicatorTemplate;
    [SerializeField] private Survivals _survivals;

    public void Init()
    {
        foreach(Survival survival in _survivals)
        {
            CreateArrow(survival.PointTargetComponent);
        }    
    }

    public void CreateArrow(PointTarget target)
    {
        TargetIndicator targetIndicator = Instantiate(_targetIndicatorTemplate, _arrowsCanvas);
        targetIndicator.Activate(target);
    }
}
